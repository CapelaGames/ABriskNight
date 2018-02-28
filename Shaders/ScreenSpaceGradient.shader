Shader "PushyPixels/VerticalScreenSpaceGradient" {
Properties
{
	_Blend("Blend", Range(0, 1)) = 0.5
	_Color ("Top Color", Color) = (1,1,1,1)
	_Color2 ("Bottom Color", Color) = (1,1,1,1)
	_MainTex("Texture 1", 2D) = ""
	_Texture2("Texture 2", 2D) = ""
}
SubShader
{
	Tags { "RenderType"="Opaque" }
	LOD 200

CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
sampler2D _Texture2;
fixed4 _Color;
fixed4 _Color2;
float _Blend;

struct Input
{
	float2 uv_MainTex;
	float2 uv_Texture2;
	float4 screenPos;
};

void surf (Input IN, inout SurfaceOutput o) {
	float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
	fixed4 c = tex2D(lerp(_Texture2, _MainTex, _Blend));
	o.Albedo = c.rgb;
	o.Alpha = c.a;
}
ENDCG
}

Fallback "VertexLit"
}
