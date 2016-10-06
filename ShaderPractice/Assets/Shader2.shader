Shader "Custom/Shader2" {
	Properties {
        _EmissiveColor("Emissive Color", Color) = (1,1,1,1)
        _AmbientColor("Ambient Color", Color) = (1,1,1,1)
        _PowerValue("Color Power", Range(0,10)) = 1.5
    }
    SubShader{
        Tags { "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        float4 _EmissiveColor;
        float4 _AmbientColor;
        float _PowerValue;

        struct Input {
            float2 uv_MainTex;
        };

		void surf (Input IN, inout SurfaceOutput o) {
            float4 c;
            c = pow((_EmissiveColor + _AmbientColor), _PowerValue);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
