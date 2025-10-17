Shader "Custom/VertexTestShader"
{
    Properties
    {
        // �����̸�("������Ƽ ǥ���̸�", ������Ƽ) = (�ʱⰪ)
        _Color("Main Color", Color) = (1, 1, 1, 0.5)
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            static half _Frequency = 10;    //  ����
            static half _Amplitude = 0.9; // ����

            v2f vert (appdata_base v)
            {
                v2f o;

                // _Time.y (����Ƽ Scene�� ���۵� ������ �ð��� �帧�� �ʴ����� �Ҽ��� ������ ���� �����Լ� ��ȯ)
                //v.vertex.xyz += -v.normal * sin(_Time.y);

                v.vertex.xyz += v.normal * sin(v.vertex.x * _Frequency + _Time.y) * _Amplitude;

                // ������ǥ -> ������ǥ -> ī�޶���ǥ -> ������ǥ ->ClipSpace
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 texcol = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return texcol * _Color;
            }
            ENDCG
        }
    }
}
