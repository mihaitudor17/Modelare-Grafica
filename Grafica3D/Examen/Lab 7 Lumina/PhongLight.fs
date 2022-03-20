#version 330 core
out vec4 FragColor;

in vec3 Normal;  
in vec3 FragPos; 
in vec4 ex_Color;

uniform vec3 lightPos; 
uniform vec3 viewPos; 
uniform vec3 lightColor;

uniform float Ka;
uniform float Kd;
uniform float Ks;
uniform float Kspec;
uniform float Klin;
uniform float Kpat;
void main()
{
    vec3 ambient = lightColor * Ka;

    vec3 LightDir = normalize(lightPos - FragPos);
    vec3 diffuse = lightColor * Kd * max(dot(Normal, LightDir), 0.0);

    float specFactor = pow(max(dot(viewPos, LightDir), 0.0), Kspec);
    vec3 specular = Ks * specFactor * lightColor;

    float d=sqrt(pow(FragPos.x-lightPos.x,2.0)+pow(FragPos.y-lightPos.y,2.0)+pow(FragPos.z-lightPos.z,2.0));
    float Katen=1.0/(1.0+Klin*d+Kpat*(d*d));

    FragColor = vec4(ambient + (diffuse + specular)*Katen, 1.0) * ex_Color;
}  