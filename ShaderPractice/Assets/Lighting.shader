Shader "Custom/Lighting" {
	Properties {
        _MainTex("Base (RGB)", 2D) = "white" {}
        _LightColor0("Color", Color) = (1,1,1,1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf LambertCustom

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

        
        sampler2D _MainTex;

        struct Input {
            float2 uv_MainTex;
        };

        half4 LightingLambertCustom(SurfaceOutput s, half3 lightDir, half atten)
        {
            half NdotL = dot(lightDir, s.Normal);
            NdotL = NdotL * 0.5f + 0.5f;

            half4 c;
            c.rgb = (s.Albedo * _LightColor0.rgb * NdotL) * (atten);
            c.a = s.Alpha;
            return c;
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
		ENDCG
	} 
	FallBack "Diffuse"
}
