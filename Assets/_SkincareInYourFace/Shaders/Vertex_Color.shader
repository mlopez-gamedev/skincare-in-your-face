Shader "Unlit/Vertex_Color"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _LightmapTex ("Lightmap Texture", 2D) = "white" {}
        _NoiseAmount("Noise amount", float)=0.1
        _Speed("Speed", float)=1
        _Darken("Darken", float)=1
        _Tint("Color Tint", color)=(0,0,0,1)
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

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color: COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color: COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _NoiseAmount;
            float _Speed;
            float _Darken;
            sampler2D _LightmapTex;
            float4 _Tint;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color= v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv+_Speed*_Time.y);
                fixed4 lightmapCol= tex2D(_LightmapTex, i.uv);
                col=i.color-(col*_NoiseAmount);
                col*=_Darken;
                col+=clamp(0,1,_Tint);
                col*= lightmapCol;
                return col;

            }
            ENDCG
        }
    }
}
