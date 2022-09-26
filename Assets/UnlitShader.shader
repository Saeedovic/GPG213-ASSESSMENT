


Shader "Unlit/UnlitShader"
{
    Properties
    {
        _Color ("color", Color) = (1,1,1,1)
    }
    SubShader
    {   
        Pass
        {
         Tags{
                "LightMode" = "ForwardBase"
                }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
          

            #include "UnityCG.cginc"

            uniform float4 _LightColor0
            

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
              
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 col : COLOR;
            };

           

            v2f vert (appdata v)
            {
                v2f o;
                o.
                float3 normalDirection = UnityObjectToWorldNormal(v.normal);
                float3 lightDir = normalize(_LightColor0 - v.position); // float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                o.normal = v.normal;
                return o;
            }

            fixed4 frag (v2f i) : COLOR
            {
                float lightDot = dot(o.normal, lightDir);

                float3 rgb = color * lightDot;
                return float4(rgb, 1.0);
            }
            ENDCG
        }
    }
}
