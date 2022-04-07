using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Utils
{
   public static Size getSizeByCollider(GameObject gameObject)
    {
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        
        return new Size
        {
            Width = collider.bounds.size.x,
            Height = collider.bounds.size.y
        };
    }
}

public class Size
{
    public float Width { get; set; }
    public float Height { get; set; }
}

