Shader "Custom/MySpecularShader" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,0)
		_Shiness ("Shiness", float) = 1
		_Gloss ("Gloss", float) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf BlinnPhong

		sampler2D _MainTex;
        float _Shiness;
        float _Gloss;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;

            o.Specular = _Shiness;
            o.Gloss = _Gloss;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
