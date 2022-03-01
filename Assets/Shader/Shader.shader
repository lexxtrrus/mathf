Shader "Playtika/MyUnlit"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Power ("Color Power", float) = 0.5
        _MainText ("Main Texture", 2D) = "white"{}
        _MyVector ("MyVector", Vector) = (0.2, 0.2, 0.2, 1)
    }
    SubShader
    {
       Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            
            float4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.color.rgb = v.normal.xyz;
                o.color.a = 1;

                float3 light = normalize( _WorldSpaceLightPos0.xyz );
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return i.color;
            }
            ENDCG
        }
    }
}
