Shader "Custom/NewSurfaceShader"
{
    Properties
    {
        _myColor ("Sample color", Color) = (1,1,1,1)
        _myEmission ("Sample emission", Color) = (1,1,1,1)
        _myNormal ("Sample normal", Color) = (1,1,1,1)
    }
    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float2 UVMainTex;
        };

        fixed4 _myColor;
        fixed4 _myEmission;
        fixed4 _myNormal;

        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _myColor.rgb;
            o.Emission = _myEmission.rgb;
            o.Normal = _myNormal.rgb;
        }
        ENDCG
    }
    Fallback "Diffuse"
}
