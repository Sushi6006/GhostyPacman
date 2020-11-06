Shader "Custom/Transparent Shader"
{
	Properties{
        //the color of surface
		_Color("Color", color) = (50, 110, 154)
        //the texture of surface
		_MainTex("Texture", 2D) = "white"{}
        //the level of transparent
		_AlphaScale("Alpha Scale",Range(0,1)) = 0.8
	}
	SubShader{
		Tags{"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}

		Pass {
			Tags { "LightMode"="ForwardBase" }

            //the depth of writing
            ZWrite Off
            //open the mix
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "Lighting.cginc"

			fixed3 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed _AlphaScale;
			
			struct a2v{
				float4 vertex:POSITION;
				float3 normal:NORMAL;
				float4 texcoord:TEXCOORD;
			};

			struct v2f{
				float4 pos:SV_POSITION;
				float3 worldNormal:NORMAL;
				float3 worldPos:TEXCOORD1;
				float2 uv:TEXCOORD2;
			};

			v2f vert(a2v v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.uv = TRANSFORM_TEX(v.texcoord,_MainTex);
				return o;
			}

			fixed4 frag(v2f o):SV_Target
			{   
                //define the texture and color
				fixed4 texColor = tex2D(_MainTex,o.uv);
				fixed3 albedo = texColor.rgb * _Color.rgb;

                //get the normal and light
				fixed3 worldNormal = normalize(o.worldNormal);
				fixed3 worldLight = normalize(UnityWorldSpaceLightDir(o.worldPos));
                
                //the ambient and diffuse reflection
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo;
				fixed3 diffuse = albedo*_LightColor0.rgb * saturate(dot(worldNormal,worldLight));

                //the final result of color
				return fixed4(ambient + diffuse, texColor.a * _AlphaScale);
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
