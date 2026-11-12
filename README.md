# Practica Vuforia

![](vuforiaPractica.gif)

## setup

Added the Vuforia Engine package to the project for AR functionality.

Removed the default Main Camera from the scene -> added Vuforia ARCamera instead.

Generated a development licence through the Vuforia Developer Portal. Copied the licence key into the Vuforia Behaviour component of the ARCamera through the Unity Inspector.

## image Target Database

Generated a Device Database and added two Single Image targets to it. Each target is an image that Vuforia must recognise -> the astronaut image and an image of a dog.

After creating the database, it was downloaded in Unity Editor format and imported into the Unity project as a `.unitypackage`.

Added the two Image Targets to the Unity scene and configured using the Image Target Behaviour component. Each target was associated with its corresponding image from the imported database.

The targets are reference points for the 3D objects. When Vuforia recognises an image through the camera, it tracks its position and orientation, allowing the associated virtual object to appear in the correct location.

## 3D Models

Selected two different 3D models from the Unity Asset Store and imported them into the project -> the warrior dog and the knight

Added each model as a child of its corresponding Image Target in the Unity Hierarchy so that the objects can follow the position and orientation of the images when they are detected by Vuforia.

Adjusted the position and scale of the models to a reasonable size to make them appear above their respective image targets.

Each image displays a different 3D object when recognised by the camera.

## interaction Event

The event is changing the color of the object to a random new color when the user clicks it with the mouse.

Attached the same script to both 3D models.

### `colorChange.cs`

using UnityEngine;

public class colorChange : MonoBehaviour
{
    private Renderer[] renderers;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    void OnMouseDown()
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
}



The script initializes and uses the Renderer to change the material color of the objects.
- **Renderer array:** The `GetComponentsInChildren<Renderer>()` method gets all the Renderer components that are attached to the object and its children (necessary because imported 3D models can have several individual meshes)
- **Start():** When the script starts, all the Renderers that are part of the model are put in an array.
- **OnMouseDown():** This method is called when the user clicks on the object.
- **Random.ColorHSV():** This method generates a random colour in the HSV colour space.
- **foreach loop:** The loop applies the generated colour to every Renderer in the model to make sure that all its visible parts change colour.

Added a Collider component to the models so that Unity could detect mouse clicks on them.

The script is attached to both objects.



# Práctica Vuforia

![](vuforiaPractica.gif)

## Configuración

Se añadió el paquete Vuforia Engine al proyecto para incorporar la funcionalidad de Realidad Aumentada.

Se eliminó la cámara predeterminada (Main Camera) de la escena y se añadió en su lugar una Vuforia ARCamera.

Se generó una licencia de desarrollo a través del portal de Vuforia Developer. La clave de licencia se copió en el componente Vuforia Behaviour de la ARCamera desde el Inspector de Unity.

## Base de datos de Image Targets

Se generó una Device Database y se añadieron dos objetivos de tipo Single Image. Cada objetivo corresponde a una imagen que Vuforia debe reconocer: la imagen del astronauta y una imagen de un perro.

Después de crear la base de datos, se descargó en formato Unity Editor y se importó al proyecto de Unity como un archivo `.unitypackage`.

Se añadieron los dos Image Targets a la escena de Unity y se configuraron mediante el componente Image Target Behaviour. Cada objetivo se asoció con su correspondiente imagen de la base de datos importada.

Los objetivos actúan como puntos de referencia para los objetos 3D. Cuando Vuforia reconoce una imagen a través de la cámara, realiza el seguimiento de su posición y orientación, permitiendo que el objeto virtual asociado aparezca en la ubicación correspondiente.

## Modelos 3D

Se seleccionaron dos modelos 3D diferentes de la Unity Asset Store y se importaron al proyecto: un perro guerrero y un caballero.

Cada modelo se añadió como hijo de su correspondiente Image Target en la jerarquía de Unity. De esta manera, los objetos pueden seguir la posición y orientación de las imágenes cuando Vuforia las detecta.

Se ajustaron la posición y la escala de los modelos para conseguir un tamaño adecuado y hacer que aparecieran sobre sus respectivos objetivos de imagen.

Cada imagen muestra un objeto 3D diferente cuando es reconocida por la cámara.

## Evento de interacción

El evento implementado consiste en cambiar el color del objeto por otro color aleatorio cuando el usuario hace clic sobre él con el ratón.

Se adjuntó el mismo script a los dos modelos 3D.

### `colorChange.cs`

```csharp
using UnityEngine;

public class colorChange : MonoBehaviour
{
    private Renderer[] renderers;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    void OnMouseDown()
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
}
```

El script inicializa y utiliza los componentes Renderer para modificar el color del material de los objetos.

- **Array de Renderer:** El método `GetComponentsInChildren<Renderer>()` obtiene todos los componentes Renderer asociados al objeto y a sus objetos hijos. Esto es necesario porque los modelos 3D importados pueden estar formados por varias mallas individuales.
- **Start():** Cuando se inicia el script, todos los componentes Renderer que forman parte del modelo se almacenan en un array.
- **OnMouseDown():** Este método se ejecuta cuando el usuario hace clic sobre el objeto.
- **Random.ColorHSV():** Este método genera un color aleatorio utilizando el espacio de color HSV.
- **Bucle foreach:** El bucle aplica el color generado a todos los componentes Renderer del modelo, asegurando que todas sus partes visibles cambien de color.

También se añadió un componente Collider a los modelos para que Unity pudiera detectar los clics del ratón sobre ellos.

El mismo script está adjunto a ambos objetos.