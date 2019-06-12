using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMicroState
{

    void UpdateState();

    void OnTriggernEnter(Collider other);

    void MoveToState(IEnemyMicroState state);

}
