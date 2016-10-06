Shader "Custom/MyFirstShader" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MyColor("My Color", Color) = (1,1,1,1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
        float4 _MyColor;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			//o.Albedo = _MyColor.rgb;
            o.Emission = _MyColor.rgb;
            o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
