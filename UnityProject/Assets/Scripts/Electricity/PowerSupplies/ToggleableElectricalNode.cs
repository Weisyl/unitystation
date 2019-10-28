﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/// <summary>
/// Allows this object to toggle its electrical node when clicked - turning the supply on or off.
/// </summary>
public class ToggleableElectricalNode : NetworkBehaviour, IInteractable<HandApply>, INodeControl
{
  	[SyncVar(hook = nameof(UpdateState))]
	public bool isOn = false;
	public ElectricalNodeControl ElectricalNodeControl;

	public void ServerPerformInteraction(HandApply interaction)
	{
		isOn = !isOn;
		UpdateServerState(isOn);
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		isOn = true;
		UpdateServerState(isOn);
	}
	public void UpdateServerState(bool _isOn)
	{
		if (isOn)
		{
			//Logger.Log("TurnOnSupply");
			ElectricalNodeControl.TurnOnSupply();
		}
		else
		{
			//Logger.Log("TurnOffSupply");
			ElectricalNodeControl.TurnOffSupply();
		}
	}

	public void PowerNetworkUpdate() { }


	public void UpdateState(bool _isOn)
	{
		isOn = _isOn;
		if (isOn)
		{
			//Logger.Log("on");
		}
		else
		{
			//Logger.Log("off");
		}
	}
}
