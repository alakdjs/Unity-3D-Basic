Shader "Custom/VertexTestShader"
{
    Properties
    {
        // 변수이름("프러퍼티 표시이름", 프로퍼티) = (초기값)
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
            static half _Frequency = 10;    //  진동
            static half _Amplitude = 0.9; // 진폭

            v2f vert (appdata_base v)
            {
                v2f o;

                // _Time.y (유니티 Scene이 시작된 이후의 시간의 흐름을 초단위로 소수점 이하의 값을 유지함서 반환)
                //v.vertex.xyz += -v.normal * sin(_Time.y);

                v.vertex.xyz += v.normal * sin(v.vertex.x * _Frequency + _Time.y) * _Amplitude;

                // 로컬좌표 -> 월드좌표 -> 카메라좌표 -> 투영좌표 ->ClipSpace
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
