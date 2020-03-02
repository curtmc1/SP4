using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0,0]")]
	public partial class HealthBarShrinkNetworkObject : NetworkObject
	{
		public const int IDENTITY = 16;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private Vector3 _oldPos;
		public event FieldEvent<Vector3> oldPosChanged;
		public InterpolateVector3 oldPosInterpolation = new InterpolateVector3() { LerpT = 0f, Enabled = false };
		public Vector3 oldPos
		{
			get { return _oldPos; }
			set
			{
				// Don't do anything if the value is the same
				if (_oldPos == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_oldPos = value;
				hasDirtyFields = true;
			}
		}

		public void SetoldPosDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_oldPos(ulong timestep)
		{
			if (oldPosChanged != null) oldPosChanged(_oldPos, timestep);
			if (fieldAltered != null) fieldAltered("oldPos", _oldPos, timestep);
		}
		[ForgeGeneratedField]
		private float _health;
		public event FieldEvent<float> healthChanged;
		public InterpolateFloat healthInterpolation = new InterpolateFloat() { LerpT = 0f, Enabled = false };
		public float health
		{
			get { return _health; }
			set
			{
				// Don't do anything if the value is the same
				if (_health == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x2;
				_health = value;
				hasDirtyFields = true;
			}
		}

		public void SethealthDirty()
		{
			_dirtyFields[0] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_health(ulong timestep)
		{
			if (healthChanged != null) healthChanged(_health, timestep);
			if (fieldAltered != null) fieldAltered("health", _health, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			oldPosInterpolation.current = oldPosInterpolation.target;
			healthInterpolation.current = healthInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _oldPos);
			UnityObjectMapper.Instance.MapBytes(data, _health);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_oldPos = UnityObjectMapper.Instance.Map<Vector3>(payload);
			oldPosInterpolation.current = _oldPos;
			oldPosInterpolation.target = _oldPos;
			RunChange_oldPos(timestep);
			_health = UnityObjectMapper.Instance.Map<float>(payload);
			healthInterpolation.current = _health;
			healthInterpolation.target = _health;
			RunChange_health(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _oldPos);
			if ((0x2 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _health);

			// Reset all the dirty fields
			for (int i = 0; i < _dirtyFields.Length; i++)
				_dirtyFields[i] = 0;

			return dirtyFieldsData;
		}

		protected override void ReadDirtyFields(BMSByte data, ulong timestep)
		{
			if (readDirtyFlags == null)
				Initialize();

			Buffer.BlockCopy(data.byteArr, data.StartIndex(), readDirtyFlags, 0, readDirtyFlags.Length);
			data.MoveStartIndex(readDirtyFlags.Length);

			if ((0x1 & readDirtyFlags[0]) != 0)
			{
				if (oldPosInterpolation.Enabled)
				{
					oldPosInterpolation.target = UnityObjectMapper.Instance.Map<Vector3>(data);
					oldPosInterpolation.Timestep = timestep;
				}
				else
				{
					_oldPos = UnityObjectMapper.Instance.Map<Vector3>(data);
					RunChange_oldPos(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[0]) != 0)
			{
				if (healthInterpolation.Enabled)
				{
					healthInterpolation.target = UnityObjectMapper.Instance.Map<float>(data);
					healthInterpolation.Timestep = timestep;
				}
				else
				{
					_health = UnityObjectMapper.Instance.Map<float>(data);
					RunChange_health(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (oldPosInterpolation.Enabled && !oldPosInterpolation.current.UnityNear(oldPosInterpolation.target, 0.0015f))
			{
				_oldPos = (Vector3)oldPosInterpolation.Interpolate();
				//RunChange_oldPos(oldPosInterpolation.Timestep);
			}
			if (healthInterpolation.Enabled && !healthInterpolation.current.UnityNear(healthInterpolation.target, 0.0015f))
			{
				_health = (float)healthInterpolation.Interpolate();
				//RunChange_health(healthInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public HealthBarShrinkNetworkObject() : base() { Initialize(); }
		public HealthBarShrinkNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public HealthBarShrinkNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
