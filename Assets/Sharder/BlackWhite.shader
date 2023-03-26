
Shader "Custom/BlackWhite" {
    
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }
    
    SubShader {
        Pass {
            Tags {"RenderType"="Opaque"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma instancing_options assumeuniformscaling
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                float gray = dot(col.rgb, float3(0.299, 0.587, 0.114));
                col.rgb = lerp(float3(0,0,0), float3(1,1,1), gray);
                return col;
            }
            

            ENDCG
        }
    }
    FallBack "Diffuse"
}
