Shader "Unlit/Shader1"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
       
        Pass
        {
            Tags{
                "LightMode" = "ForwardBase"
                
                }
            CGPROGRAM
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members diffuse)
#pragma exclude_renderers d3d11
            #pragma vertex vert
            #pragma fragment frag
           

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

           //uniform fixed4 _LightColor0;

            struct appdata
            {
                float4 uv : TEXCOORD0;
                float3 normal : NORMAL;
                float4 vertex : POSITION;

            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
                float3 diffuse;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _LightColor0;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.diffuse=diffuse;
                return o;
            } 

            fixed4 frag (v2f i) : SV_Target
            {
                float3 normaldir = UnityObjectToWorldNormal(i.normal);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 diff = max(dot(normaldir, lightDirection), 0.0);
                float3 diffuse = diff * _LightColor0;
                
                fixed4 col = diffuse;
                
                return col;
            }
            ENDCG
        }
    }
}
