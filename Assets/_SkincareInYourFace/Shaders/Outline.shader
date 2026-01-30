Shader "Unlit/Outline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color outline", color)=(1,1,1,1)
        _Thickness("Thickness", float)=0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100			
        ZWrite On
		Cull Front

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag


            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal: NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;

            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Thickness;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
				v.vertex.xyz += (v.normal *  _Thickness);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
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
