using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User 
{
    public string email;
    public float width;
    public float depth;
    public string model;

    public User(string email, float width, float depth, string model)
    {
        this.email = email;
        this.width = width;
        this.depth = depth;
        this.model = model;
    }
}
