Shader "Unlit/S_Hole"
{
    Properties
    {
        _Pivot ("Pivot Position", Vector) = (0,0,0,0)
        _Strength ("Attraction Strength", Range(-20
            ,1)) = 0.5
        _Color ("Color", Color) = (1,1,1,1)
        _MaxDistance ("Max Influence Distance", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
            };
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };
            
            float3 _Pivot;
            float _Strength;
            float4 _Color;
            float _MaxDistance;
            
            v2f vert(appdata v)
            {
                v2f o;
                
                // Distance du sommet au pivot
                float3 dir = _Pivot - v.vertex.xyz;
                float dist = length(dir);
                
                // Déplacement du sommet vers le pivot seulement si dans la distance max
                if (dist <= _MaxDistance)
                {
                    v.vertex.xyz += dir * _Strength;
                }
                
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.color = _Color;
                return o;
            }
            
            fixed4 frag(v2f i) : SV_Target
            {
                return i.color;
            }
            
            ENDCG
        }
    }
}


