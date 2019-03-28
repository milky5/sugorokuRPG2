using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    bool isMoving { get; set; }
    bool firstMass { get; set; }
    StoryList story { get; set; }

    void Move();
}
