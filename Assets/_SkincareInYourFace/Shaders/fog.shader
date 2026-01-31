Shader "Unlit/fog"
{
    Properties
    {
        _NoiseTex ("Texture", 2D) = "white" {}
        _NoiseTex2 ("Texture2", 2D) = "white" {}
        _Mask("Texture mask", 2D) = "white" {}
        _Speed1("Speed1", float)=1
        _Speed2("Speed2", float)=2
        _FogColor("Fog Color", color)=(1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        Zwrite Off
        AlphaTest Greater .001

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

            sampler2D _NoiseTex;
            float4 _NoiseTex_ST;
            sampler2D _NoiseTex2;
            float4 _NoiseTex2_ST;
            sampler2D _Mask;
            float4 _Mask_ST;
            float4 _FogColor;
            float _Speed1;
            float _Speed2;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _Mask);
                o.color=v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                _Speed1*=0.1;
                _Speed2*=0.1;
                fixed4 mask= tex2D(_Mask, i.uv);
                fixed4 col = tex2D(_NoiseTex, i.uv*_NoiseTex_ST.xy+_NoiseTex_ST.zw+_Speed1*_Time.y);
                fixed4 col2= tex2D(_NoiseTex2, i.uv*_NoiseTex2_ST.xy+_NoiseTex2_ST.zw+_Speed2*_Time.y);
                col=col+col2;
                col*=_FogColor;
                col.a=(0,1, mask.r*col.r)*i.color.a;
                col*=i.color;
                return col;
            }
            ENDCG
        }
    }
}
