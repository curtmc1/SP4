using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedRPC("{\"types\":[[\"Vector3\", \"Quaternion\", \"bool\"][\"Vector3\", \"Quaternion\", \"bool\"][\"bool\"][\"bool\"]]")]
	[GeneratedRPCVariableNames("{\"types\":[[\"position\", \"rotation\", \"isOrNot\"][\"position\", \"rotation\", \"isOrNot\"][\"gravity\"][\"gravity\"]]")]
	public abstract partial class EnvironmentalBehavior : NetworkBehavior
	{
		public const byte RPC_UPDATE_SERVER = 0 + 5;
		public const byte RPC_UPDATE_CLIENT = 1 + 5;
		public const byte RPC_USE_GRAVITY_SERVER = 2 + 5;
		public const byte RPC_USE_GRAVITY_CLIENT = 3 + 5;
		
		public EnvironmentalNetworkObject networkObject = null;

		public override void Initialize(NetworkObject obj)
		{
			// We have already initialized this object
			if (networkObject != null && networkObject.AttachedBehavior != null)
				return;
			
			networkObject = (EnvironmentalNetworkObject)obj;
			networkObject.AttachedBehavior = this;

			base.SetupHelperRpcs(networkObject);
			networkObject.RegisterRpc("UpdateServer", UpdateServer, typeof(Vector3), typeof(Quaternion), typeof(bool));
			networkObject.RegisterRpc("UpdateClient", UpdateClient, typeof(Vector3), typeof(Quaternion), typeof(bool));
			networkObject.RegisterRpc("UseGravityServer", UseGravityServer, typeof(bool));
			networkObject.RegisterRpc("UseGravityClient", UseGravityClient, typeof(bool));

			networkObject.onDestroy += DestroyGameObject;

			if (!obj.IsOwner)
			{
				if (!skipAttachIds.ContainsKey(obj.NetworkId)){
					uint newId = obj.NetworkId + 1;
					ProcessOthers(gameObject.transform, ref newId);
				}
				else
					skipAttachIds.Remove(obj.NetworkId);
			}

			if (obj.Metadata != null)
			{
				byte transformFlags = obj.Metadata[0];

				if (transformFlags != 0)
				{
					BMSByte metadataTransform = new BMSByte();
					metadataTransform.Clone(obj.Metadata);
					metadataTransform.MoveStartIndex(1);

					if ((transformFlags & 0x01) != 0 && (transformFlags & 0x02) != 0)
					{
						MainThreadManager.Run(() =>
						{
							transform.position = ObjectMapper.Instance.Map<Vector3>(metadataTransform);
							transform.rotation = ObjectMapper.Instance.Map<Quaternion>(metadataTransform);
						});
					}
					else if ((transformFlags & 0x01) != 0)
					{
						MainThreadManager.Run(() => { transform.position = ObjectMapper.Instance.Map<Vector3>(metadataTransform); });
					}
					else if ((transformFlags & 0x02) != 0)
					{
						MainThreadManager.Run(() => { transform.rotation = ObjectMapper.Instance.Map<Quaternion>(metadataTransform); });
					}
				}
			}

			MainThreadManager.Run(() =>
			{
				NetworkStart();
				networkObject.Networker.FlushCreateActions(networkObject);
			});
		}

		protected override void CompleteRegistration()
		{
			base.CompleteRegistration();
			networkObject.ReleaseCreateBuffer();
		}

		public override void Initialize(NetWorker networker, byte[] metadata = null)
		{
			Initialize(new EnvironmentalNetworkObject(networker, createCode: TempAttachCode, metadata: metadata));
		}

		private void DestroyGameObject(NetWorker sender)
		{
			MainThreadManager.Run(() => { try { Destroy(gameObject); } catch { } });
			networkObject.onDestroy -= DestroyGameObject;
		}

		public override NetworkObject CreateNetworkObject(NetWorker networker, int createCode, byte[] metadata = null)
		{
			return new EnvironmentalNetworkObject(networker, this, createCode, metadata);
		}

		protected override void InitializedTransform()
		{
			networkObject.SnapInterpolations();
		}

		/// <summary>
		/// Arguments:
		/// Vector3 position
		/// Quaternion rotation
		/// bool isOrNot
		/// </summary>
		public abstract void UpdateServer(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// Vector3 position
		/// Quaternion rotation
		/// bool isOrNot
		/// </summary>
		public abstract void UpdateClient(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// bool gravity
		/// </summary>
		public abstract void UseGravityServer(RpcArgs args);
		/// <summary>
		/// Arguments:
		/// bool gravity
		/// </summary>
		public abstract void UseGravityClient(RpcArgs args);

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}