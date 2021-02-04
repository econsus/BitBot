using UnityEngine;
using System;

//Class untuk me-reference Vector2Variable
//  Ceritanya class ini sebagai penengah diantara scriptable object Vector2Variable dan pengguna nilai Vector2Variable
//  supaya jika ada yg ingin mengambil nilai Vector2Variable tidak perlu melakukan hard reference sehingga lebih modular.
[Serializable]
public class Vector2Reference
{
    public Vector2Variable variable; //Vector2Variable yang di-reference

    public Vector2Reference() { }

    //Mengkomunikasikan currentValue dari Vector2Variable
    public Vector2 Value
    {
        get { return variable.currentValue; }
        set { variable.SetValue(value); }
    }
    //Conversion operator dari Vector2Reference ke Vector2
    //public static implicit operator Vector2(Vector2Reference reference)
    //{
    //    return reference.Value;
    //}
}
