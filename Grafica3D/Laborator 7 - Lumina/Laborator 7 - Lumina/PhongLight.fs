#version 330 core
out vec4 FragColor;
in vec3 Normal;  
in vec3 FragPos; 
uniform vec3 lightPos; 
uniform vec3 viewPos; 
uniform vec3 lightColor;
uniform vec3 objectColor;

uniform float Ka=0.1;
uniform float Kd=0.9;


void main()
{
    vec3 ambient =  lightColor * Ka;

    vec3 LightDir = normalize(lightPos - FragPos);

    vec3 diffuse = lightColor * Kd * max(dot(Normal,LightDir),0.0);
    FragColor = vec4(ambient + diffuse,1.0) * vec4(objectColor, 1.0);
}