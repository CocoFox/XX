/*{
	"CREDIT": "by mojovideotech",
	"DESCRIPTION": "",
	"CATEGORIES": [
	],
	"INPUTS": [
 {
            "NAME": "size",
            "TYPE": "float",
           "DEFAULT": 20,
            "MIN": 9,
            "MAX": 99
        },
         {
            "NAME": "speed",
            "TYPE": "float",
           "DEFAULT": 1.0,
            "MIN": -1.0,
            "MAX": 3.0
        },
                 {
            "NAME": "r",
            "TYPE": "float",
           "DEFAULT": 2.0,
            "MIN": 1.0,
            "MAX": 3.0
        },
                 
                 {
            "NAME": "g",
            "TYPE": "float",
           "DEFAULT": 2.0,
            "MIN": 1.0,
            "MAX": 3.0
        },
                 {
            "NAME": "b",
            "TYPE": "float",
           "DEFAULT": 2.0,
            "MIN": 1.0,
            "MAX": 3.0
        },
        	{
		
      "MAX": [
        2000,
        2000
      ],
      "MIN": [
        1,
        1
      ],
      "DEFAULT":[111,333],
			"NAME": "seed",
			"TYPE": "point2D"
		}
	]
}*/

// ALifeLEDWall by mojovideotech
// based on:
// http://glslsandbox.com/e#25692.0

#ifdef GL_ES
precision mediump float;
#endif


float rand(vec2 co){
  return fract(tan(dot(co.xy, vec2(seed))) * log2(TIME)) ;
}

void main (void) {
	vec2 v = gl_FragCoord.xy  / size ;
	vec3 brightness = vec3 ( fract(rand(floor(v)) + TIME/1.1*speed) , fract(rand(floor(v)) + TIME/1.2*speed), fract(rand(floor(v)) + TIME/1.3*speed)) ;
	brightness *= 0.5 - distance(fract(v), vec2(0.45, 0.45));

	gl_FragColor = vec4(brightness.r*r, brightness.g*g, brightness.b*b, 1.0);
}