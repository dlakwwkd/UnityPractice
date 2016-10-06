Shader "Custom/RimLight" {
    Properties{
        _MainTex("Base (RGB)", 2D) = "white" {}
        _RimPower("Rim Power", float) = 1
    }
    SubShader{
        Tags{ "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf BlinnPhong

        sampler2D _MainTex;
        float _RimPower;

        struct Input {
            float2 uv_MainTex;
            float3 viewDir;
        };

        void surf(Input IN, inout SurfaceOutput o) {
            half4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;

            float rim = saturate(dot(normalize(IN.viewDir), o.Normal));
            rim = 1 - rim;
            o.Emission = c.rgb * pow(rim, _RimPower);
        }
		ENDCG
	} 
	FallBack "Diffuse"
}
