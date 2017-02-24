Shader "Custom/Dissolve_2" 
{
	Properties {
		//base
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		//normal
		_BumpMap ("Bump Map", 2D) = "bump" {}

		//bumped
		_disolve ("Albedo (RGB)", 2D) = "white" {}
		_DissolvePercentage("DissolvePercentage", Range(0,1)) = 0.0
		_ShowTexture("ShowTexture", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _disolve;
		sampler2D _BumpMap;

		struct Input {
			float2 uv_MainTex;
			float2 uv_disolve;
			float2 uv_BumpMap;
		};

		half _Glossiness;
		half _Metallic;
		half _DissolvePercentage;
    	half _ShowTexture;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));

			half gradient = tex2D(_disolve, IN.uv_disolve).r;
			clip(gradient- _DissolvePercentage);

			fixed4 c2 = lerp(1, gradient, _ShowTexture) * _Color;

		}
		ENDCG
	}
	FallBack "Diffuse"
}
