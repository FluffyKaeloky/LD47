using AlmenaraGames;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLPooledAudioPlay : Action
{
    public SharedAudioObject audioObject;

    public override TaskStatus OnUpdate()
    {
        if (audioObject == null)
            return TaskStatus.Failure;

        MultiAudioManager.PlayAudioObject(audioObject.Value, transform.position);

        return TaskStatus.Success;
    }
}
