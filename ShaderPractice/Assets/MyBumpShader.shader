Shader "Custom/MyBumpShader" {
    Properties{
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _BumpTex("Bump Tex", 2D) = "white" {}
    }
    SubShader{
        Tags{ "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        sampler2D _BumpTex;

        struct Input {
            float2 uv_MainTex;
            float2 uv_BumpTex;
        };

        void surf(Input IN, inout SurfaceOutput o) {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;

            float3 bumpNormal = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));
            o.Normal = bumpNormal;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
