Shader "Unlit/Shader11"
{
   Properties
	{
		_MainTex ( "Base (RGB)", 2D ) = "white" {}
		_Color( "Material Color", Color ) = ( 1.0, 1.0, 1.0, 1.0 )
	}
	
	SubShader
	{
		Tags { "LightMode" = "ForwardBase" }
		
		Pass
		{
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           

            #include "UnityCG.cginc"

            uniform sampler2D _MainTex;
            uniform float4 _MainTex_ST;
            uniform fixed4 _LightColor0;
            uniform fixed4 _Color;


            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 uv : TEXCOORD0;

            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 color : COLOR0;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            

            v2f vert (appdata i)
            {
                v2f o;
                o.pos = UnityObjectToClipPos( i.vertex);
                o.uv = TRANSFORM_TEX(i.uv, _MainTex);
                float3 normaldir = UnityObjectToWorldNormal(i.normal);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float ndotl = dot( normaldir, lightDirection );
                float3 diffuse = _LightColor0.xyz * _Color.rgb * max(ndotl, 0.0);
                o.color = fixed4(diffuse, 1.0);
                
                return o;
            }

            fixed4 frag (v2f i) : SV_TARGET
            {
                return tex2D(_MainTex,i.uv) * i.color;
                }
            
             
           
            ENDCG
        }
    }
}
