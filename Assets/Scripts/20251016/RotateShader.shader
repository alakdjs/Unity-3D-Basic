Shader "Custom/RotateShader"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
        _SubMainTex ("SubTexture!!!", 2D) = "white" {}
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
            #include "UnityCG.cginc"

            fixed4 _Color;


            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

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
                    0, -s, -c, 0,
                    0, 0, 0, 1
                );

                // Z축 기준 회전 행렬
                float4x4 rotationZ = float4x4(
                    c, s, 0, 0,
                    -s, c, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1
                );

                // 오브젝트 로컬 -> 월드좌표 변환
                float4 worldPos = mul(unity_ObjectToWorld, v.vertex);

                // 크기변환행렬
                worldPos = mul(scaleMatrix, worldPos);

                // 정점 회전
                worldPos = mul(rotationZ, worldPos);

                // 월드좌표 -> 클립좌표로 변환
                o.vertex = mul(UNITY_MATRIX_VP, worldPos);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
    }
}
