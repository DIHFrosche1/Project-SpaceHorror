using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMicroState
{
    void Enter();

    void UpdateState();

    void OnTriggernEnter(Collider other);

    void MoveToState(IEnemyMicroState state);

}
