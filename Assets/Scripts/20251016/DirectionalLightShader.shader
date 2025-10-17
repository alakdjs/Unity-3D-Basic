Shader "Custom/DirectionalLightShader"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1) // ������Ʈ �⺻����
        _DiffuseTex ("Diffuse Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            // Unity�� ���� ���⼺ ���� ������ ����� ����ϱ� ���� �±�
            Tags {"LightMode" = "ForwardBase"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc" // Unity�� ���� ���� ����

            struct appdata
            {
                float4 vertex : POSITION; // ���� ��ġ (���ð���)
                float3 normal : NORMAL; // ���� ���� (���ð���)
                float2 uv : TEXCOORD0; // Texture UV ��ǥ
            };

            struct v2f
            {
                float4 pos : SV_POSITION; // Ŭ�� ���� ��ġ (ȭ����ǥ)
                float2 uv : TEXCOORD0; // Texture UV ��ǥ
                float3 worldNormal : NORMAL; // ������� ����
                float3 worldLightDir : TEXCOORD1; // ������� ���� ����
            };

            fixed4 _Color;
            sampler2D _DiffuseTex;
            float4 _DiffuseTex_ST; // �ؽ�ó Ÿ�ϸ�/������ ����

            v2f vert (appdata v)
            {
                v2f o;


                // ȸ���ӵ�
                float t = _Time.y * 1.0;

                // ũ�⺯ȯ���
                float4x4 scaleMatrix = float4x4( 
                    2, 0, 0, 0,
                    0, 2, 0, 0,
                    0, 0, 2, 0,
                    0, 0, 0, 1
                );

                //
                float c = cos(t);
                float s = sin(t);

                // Y�� ���� ȸ�� ���
                float4x4 rotationY = float4x4( 
                    c, 0, s, 0,
                    0, 1, 0, 0,
                    -s, 0, c, 0,
                    0, 0, 0, 1
                );

                // X�� ���� ȸ�� ���
                float4x4 rotationX = float4x4(
                    1, 0, 0, 0,
                    0, c, s, 0,
                    0, -s, c, 0,
                    0, 0, 0, 1
                );

                // Z�� ���� ȸ�� ���
                float4x4 rotationZ = float4x4(
                    c, s, 0, 0,
                    -s, c, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1
                );

                // ������Ʈ ���� -> ������ǥ��ȯ
                float4 worldPos = mul(unity_ObjectToWorld, v.vertex);

                // ũ�⺯ȯ���
                worldPos = mul(scaleMatrix, worldPos);

                // ����ȸ��
                worldPos = mul(rotationX, worldPos);

                // ������ǥ -> Ŭ����ǥ�� ��ȯ
                o.pos = mul(UNITY_MATRIX_VP, worldPos);

                /*
                // ���� x ���庯ȯ��� x ī�޶�ȯ��� x ������ȯ��� => Ŭ������ ���� (���� ȭ����ġ)
                o.pos = UnityObjectToClipPos(v.vertex);
                */
                o.uv = TRANSFORM_TEX(v.uv, _DiffuseTex); // �Է¹��� UV ��ǥ���� ����

                // �������� ���� -> ���� �������� ��ȯ
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
