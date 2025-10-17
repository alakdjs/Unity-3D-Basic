Shader "Custom/DirectionalLightShader"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1) // 오브젝트 기본색상
        _DiffuseTex ("Diffuse Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            // Unity의 내장 방향성 광원 변수와 기능을 사용하기 위한 태그
            Tags {"LightMode" = "ForwardBase"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc" // Unity의 광원 변수 포함

            struct appdata
            {
                float4 vertex : POSITION; // 정점 위치 (로컬공간)
                float3 normal : NORMAL; // 정점 법선 (로컬공간)
                float2 uv : TEXCOORD0; // Texture UV 좌표
            };

            struct v2f
            {
                float4 pos : SV_POSITION; // 클립 공간 위치 (화면좌표)
                float2 uv : TEXCOORD0; // Texture UV 좌표
                float3 worldNormal : NORMAL; // 월드공간 법선
                float3 worldLightDir : TEXCOORD1; // 월드공간 광원 방향
            };

            fixed4 _Color;
            sampler2D _DiffuseTex;
            float4 _DiffuseTex_ST; // 텍스처 타일링/오프셋 변수

            v2f vert (appdata v)
            {
                v2f o;


                // 회전속도
                float t = _Time.y * 1.0;

                // 크기변환행렬
                float4x4 scaleMatrix = float4x4( 
                    2, 0, 0, 0,
                    0, 2, 0, 0,
                    0, 0, 2, 0,
                    0, 0, 0, 1
                );

                //
                float c = cos(t);
                float s = sin(t);

                // Y축 기준 회전 행렬
                float4x4 rotationY = float4x4( 
                    c, 0, s, 0,
                    0, 1, 0, 0,
                    -s, 0, c, 0,
                    0, 0, 0, 1
                );

                // X축 기준 회전 행렬
                float4x4 rotationX = float4x4(
                    1, 0, 0, 0,
                    0, c, s, 0,
                    0, -s, c, 0,
                    0, 0, 0, 1
                );

                // Z축 기준 회전 행렬
                float4x4 rotationZ = float4x4(
                    c, s, 0, 0,
                    -s, c, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1
                );

                // 오브젝트 로컬 -> 월드좌표변환
                float4 worldPos = mul(unity_ObjectToWorld, v.vertex);

                // 크기변환행렬
                worldPos = mul(scaleMatrix, worldPos);

                // 정점회전
                worldPos = mul(rotationX, worldPos);

                // 월드좌표 -> 클립좌표로 변환
                o.pos = mul(UNITY_MATRIX_VP, worldPos);

                /*
                // 정점 x 월드변환행렬 x 카메라변환행렬 x 투영변환행렬 => 클립공간 정점 (최종 화면위치)
                o.pos = UnityObjectToClipPos(v.vertex);
                */
                o.uv = TRANSFORM_TEX(v.uv, _DiffuseTex); // 입력받은 UV 좌표값을 보정

                // 법선벡터 로컬 -> 월드 공간으로 변환
                o.worldNormal = UnityObjectToWorldNormal(v.normal);

                o.worldLightDir = WorldSpaceLightDir(v.vertex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 texColor = tex2D(_DiffuseTex, i.uv) * _Color;

                float3 normal = normalize(i.worldNormal);
                float3 lightDir = normalize(i.worldLightDir);

                float NdotL = dot(normal, -lightDir);

                float diffuseIntensity = max(0.0, NdotL);

                fixed3 diffuse = _LightColor0.rgb * diffuseIntensity * texColor.rgb;

                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * texColor.rgb;

                fixed3 finalColor = ambient + diffuse;

                return fixed4(finalColor, texColor.a);
            }
            ENDCG
        }
    }
}
