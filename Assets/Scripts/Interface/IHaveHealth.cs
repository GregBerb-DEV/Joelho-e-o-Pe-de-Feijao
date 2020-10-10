using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHaveHealth{
    void TakeDamage(int damageTaken);
    void Kill();
}
