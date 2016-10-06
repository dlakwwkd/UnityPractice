Shader "Custom/VertexPainterShader" {
	Properties {
		_MainTex1 ("Tex1 (RGB)", 2D) = "white" {}
		_MainTex2 ("Tex2 (RGB)", 2D) = "white" {}
		_MainTex3 ("Tex3 (RGB)", 2D) = "white" {}
		_MainTex4 ("Tex4 (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex1;
		sampler2D _MainTex2;
        sampler2D _MainTex3;
        sampler2D _MainTex4;

		struct Input {
            float2 uv_MainTex1;
            float2 uv_MainTex2;
            float2 uv_MainTex3;
            float2 uv_MainTex4;
            float4 color : COLOR;
		};

		void surf (Input IN, inout SurfaceOutput o) {
            half4 c1 = tex2D(_MainTex1, IN.uv_MainTex1);
            half4 c2 = tex2D(_MainTex2, IN.uv_MainTex2);
            half4 c3 = tex2D(_MainTex3, IN.uv_MainTex3);
            half4 c4 = tex2D(_MainTex4, IN.uv_MainTex4);

            float4 finalColor = lerp(c1, c2, IN.color.r);
            finalColor = lerp(finalColor, c3, IN.color.g);
            finalColor = lerp(finalColor, c4, IN.color.b);

			//o.Albedo = c.rgb;
            o.Emission = finalColor.rgb;
			o.Alpha = finalColor.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
