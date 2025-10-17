Shader "Custom/NormalMappingShader"
{    
    Properties
    {
        _MainTex ("Albedo Texture", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _NormalStrength ("Normal Strength", Range(0, 2)) = 1.0
        _Color ("Color", Color) = (1,1,1,1)
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        Pass
        {
            Tags { "LightMode"="ForwardBase" }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            
            // Properties
            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NormalMap;
            float4 _NormalMap_ST;
            float _NormalStrength;
            fixed4 _Color;
            
            // Vertex Shader Input
            struct appdata
            {
                float4 vertex : POSITION;      // 정점 위치
                float3 normal : NORMAL;        // 정점 노멀
                float4 tangent : TANGENT;      // 접선 벡터
                float2 uv : TEXCOORD0;         // UV 좌표
            };
            
            // Vertex to Fragment
            struct v2f
            {
                float4 pos : SV_POSITION;      // 클립 공간 위치
                float2 uv : TEXCOORD0;         // 메인 텍스처 UV
                float2 uv_normal : TEXCOORD1;  // 노멀맵 UV
                float3 worldPos : TEXCOORD2;   // 월드 위치
                float3 tspace0 : TEXCOORD3;    // TBN 행렬 첫번째 행
                float3 tspace1 : TEXCOORD4;    // TBN 행렬 두번째 행
                float3 tspace2 : TEXCOORD5;    // TBN 행렬 세번째 행
            };
            
            // Vertex Shader
            v2f vert(appdata v)
            {
                v2f o;
                
                // 클립 공간 위치 계산
                o.pos = UnityObjectToClipPos(v.vertex);
                
                // UV 좌표 변환 (tiling, offset 적용)
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv_normal = TRANSFORM_TEX(v.uv, _NormalMap);
                
                // 월드 공간 위치
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                
                // 월드 공간 노멀, 접선, 종법선 계산
                float3 worldNormal = UnityObjectToWorldNormal(v.normal);
                float3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
                float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w;
                
                // TBN 행렬을 각 행으로 저장 (메모리 효율)
                o.tspace0 = float3(worldTangent.x, worldBinormal.x, worldNormal.x);
                o.tspace1 = float3(worldTangent.y, worldBinormal.y, worldNormal.y);
                o.tspace2 = float3(worldTangent.z, worldBinormal.z, worldNormal.z);
                
                return o;
            }
            
            // Pixel/Fragment Shader
            fixed4 frag(v2f i) : SV_Target
            {
                // 1. 메인 텍스처 샘플링
                fixed4 albedo = tex2D(_MainTex, i.uv) * _Color;
                
                // 2. 노멀맵 샘플링
                // 노멀맵은 0~1 범위이므로 -1~1 범위로 변환
                fixed3 tangentNormal = UnpackNormal(tex2D(_NormalMap, i.uv_normal));
                
                // 노멀 강도 적용
                tangentNormal.xy *= _NormalStrength;
                
                // 노멀 재정규화 (z 성분 복원)
                tangentNormal.z = sqrt(1.0 - saturate(dot(tangentNormal.xy, tangentNormal.xy)));
                
                // 3. 탄젠트 공간 노멀을 월드 공간으로 변환
                // TBN 행렬 적용
                float3 worldNormal;
                worldNormal.x = dot(i.tspace0, tangentNormal);
                worldNormal.y = dot(i.tspace1, tangentNormal);
                worldNormal.z = dot(i.tspace2, tangentNormal);
                worldNormal = normalize(worldNormal);
                
                // 4. 조명 계산
                // 메인 디렉셔널 라이트 방향
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                
                // Diffuse (Lambert)
                float NdotL = max(0, dot(worldNormal, lightDir));
                fixed3 diffuse = albedo.rgb * _LightColor0.rgb * NdotL;
                
                // Ambient
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo.rgb;
                
                // 5. 최종 색상
                fixed3 finalColor = ambient + diffuse;
                
                return fixed4(finalColor, albedo.a);
            }
            
            ENDCG
        }
    }
    
    FallBack "Diffuse"
}