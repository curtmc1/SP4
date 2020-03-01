using BeardedManStudios.Forge.Networking.Frame;
using System;
using MainThreadManager = BeardedManStudios.Forge.Networking.Unity.MainThreadManager;

namespace BeardedManStudios.Forge.Networking.Generated
{
	public partial class NetworkObjectFactory : NetworkObjectFactoryBase
	{
		public override void NetworkCreateObject(NetWorker networker, int identity, uint id, FrameStream frame, Action<NetworkObject> callback)
		{
			if (networker.IsServer)
			{
				if (frame.Sender != null && frame.Sender != networker.Me)
				{
					if (!ValidateCreateRequest(networker, identity, id, frame))
						return;
				}
			}
			
			bool availableCallback = false;
			NetworkObject obj = null;
			MainThreadManager.Run(() =>
			{
				switch (identity)
				{
					case AINetworkObject.IDENTITY:
						availableCallback = true;
						obj = new AINetworkObject(networker, id, frame);
						break;
					case AISpawnerNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new AISpawnerNetworkObject(networker, id, frame);
						break;
					case BulletNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new BulletNetworkObject(networker, id, frame);
						break;
					case ChangeFaceNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new ChangeFaceNetworkObject(networker, id, frame);
						break;
					case ChatManagerNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new ChatManagerNetworkObject(networker, id, frame);
						break;
					case ChatterManagerNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new ChatterManagerNetworkObject(networker, id, frame);
						break;
					case CubeForgeGameNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new CubeForgeGameNetworkObject(networker, id, frame);
						break;
					case EnemyHealthNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new EnemyHealthNetworkObject(networker, id, frame);
						break;
					case EnemyLaserNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new EnemyLaserNetworkObject(networker, id, frame);
						break;
					case EnemyMovementNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new EnemyMovementNetworkObject(networker, id, frame);
						break;
					case EnemyStatesNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new EnemyStatesNetworkObject(networker, id, frame);
						break;
					case EnvironmentalNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new EnvironmentalNetworkObject(networker, id, frame);
						break;
					case ExampleProximityPlayerNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new ExampleProximityPlayerNetworkObject(networker, id, frame);
						break;
					case GameLogicNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new GameLogicNetworkObject(networker, id, frame);
						break;
					case GunNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new GunNetworkObject(networker, id, frame);
						break;
					case HealthBarShrinkNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new HealthBarShrinkNetworkObject(networker, id, frame);
						break;
					case HealthPotNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new HealthPotNetworkObject(networker, id, frame);
						break;
					case HitMarkerNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new HitMarkerNetworkObject(networker, id, frame);
						break;
					case NetworkCameraNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new NetworkCameraNetworkObject(networker, id, frame);
						break;
					case PistolNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new PistolNetworkObject(networker, id, frame);
						break;
					case PlayerNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new PlayerNetworkObject(networker, id, frame);
						break;
					case SetUpPlayerNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new SetUpPlayerNetworkObject(networker, id, frame);
						break;
					case TestNetworkObject.IDENTITY:
						availableCallback = true;
						obj = new TestNetworkObject(networker, id, frame);
						break;
				}

				if (!availableCallback)
					base.NetworkCreateObject(networker, identity, id, frame, callback);
				else if (callback != null)
					callback(obj);
			});
		}

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}