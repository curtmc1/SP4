using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0.15,0.15,0,0]")]
	public partial class HealthPotNetworkObject : NetworkObject
	{
		public const int IDENTITY = 17;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private Vector3 _position;
		public event FieldEvent<Vector3> positionChanged;
		public InterpolateVector3 positionInterpolation = new InterpolateVector3() { LerpT = 0.15f, Enabled = true };
		public Vector3 position
		{
			get { return _position; }
			set
			{
				// Don't do anything if the value is the same
				if (_position == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_position = value;
				hasDirtyFields = true;
			}
		}

		public void SetpositionDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_position(ulong timestep)
		{
			if (positionChanged != null) positionChanged(_position, timestep);
			if (fieldAltered != null) fieldAltered("position", _position, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _rotation;
		public event FieldEvent<Quaternion> rotationChanged;
		public InterpolateQuaternion rotationInterpolation = new InterpolateQuaternion() { LerpT = 0.15f, Enabled = true };
		public Quaternion rotation
		{
			get { return _rotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_rotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x2;
				_rotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetrotationDirty()
		{
			_dirtyFields[0] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_rotation(ulong timestep)
		{
			if (rotationChanged != null) rotationChanged(_rotation, timestep);
			if (fieldAltered != null) fieldAltered("rotation", _rotation, timestep);
		}
		[ForgeGeneratedField]
		private bool _gotUse;
		public event FieldEvent<bool> gotUseChanged;
		public Interpolated<bool> gotUseInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool gotUse
		{
			get { return _gotUse; }
			set
			{
				// Don't do anything if the value is the same
				if (_gotUse == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x4;
				_gotUse = value;
				hasDirtyFields = true;
			}
		}

		public void SetgotUseDirty()
		{
			_dirtyFields[0] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_gotUse(ulong timestep)
		{
			if (gotUseChanged != null) gotUseChanged(_gotUse, timestep);
			if (fieldAltered != null) fieldAltered("gotUse", _gotUse, timestep);
		}
		[ForgeGeneratedField]
		private bool _canDisable;
		public event FieldEvent<bool> canDisableChanged;
		public Interpolated<bool> canDisableInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool canDisable
		{
			get { return _canDisable; }
			set
			{
				// Don't do anything if the value is the same
				if (_canDisable == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x8;
				_canDisable = value;
				hasDirtyFields = true;
			}
		}

		public void SetcanDisableDirty()
		{
			_dirtyFields[0] |= 0x8;
			hasDirtyFields = true;
		}

		private void RunChange_canDisable(ulong timestep)
		{
			if (canDisableChanged != null) canDisableChanged(_canDisable, timestep);
			if (fieldAltered != null) fieldAltered("canDisable", _canDisable, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			positionInterpolation.current = positionInterpolation.target;
			rotationInterpolation.current = rotationInterpolation.target;
			gotUseInterpolation.current = gotUseInterpolation.target;
			canDisableInterpolation.current = canDisableInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _position);
			UnityObjectMapper.Instance.MapBytes(data, _rotation);
			UnityObjectMapper.Instance.MapBytes(data, _gotUse);
			UnityObjectMapper.Instance.MapBytes(data, _canDisable);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_position = UnityObjectMapper.Instance.Map<Vector3>(payload);
			positionInterpolation.current = _position;
			positionInterpolation.target = _position;
			RunChange_position(timestep);
			_rotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			rotationInterpolation.current = _rotation;
			rotationInterpolation.target = _rotation;
			RunChange_rotation(timestep);
			_gotUse = UnityObjectMapper.Instance.Map<bool>(payload);
			gotUseInterpolation.current = _gotUse;
			gotUseInterpolation.target = _gotUse;
			RunChange_gotUse(timestep);
			_canDisable = UnityObjectMapper.Instance.Map<bool>(payload);
			canDisableInterpolation.current = _canDisable;
			canDisableInterpolation.target = _canDisable;
			RunChange_canDisable(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _position);
			if ((0x2 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _rotation);
			if ((0x4 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _gotUse);
			if ((0x8 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _canDisable);

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
				if (positionInterpolation.Enabled)
				{
					positionInterpolation.target = UnityObjectMapper.Instance.Map<Vector3>(data);
					positionInterpolation.Timestep = timestep;
				}
				else
				{
					_position = UnityObjectMapper.Instance.Map<Vector3>(data);
					RunChange_position(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[0]) != 0)
			{
				if (rotationInterpolation.Enabled)
				{
					rotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					rotationInterpolation.Timestep = timestep;
				}
				else
				{
					_rotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_rotation(timestep);
				}
			}
			if ((0x4 & readDirtyFlags[0]) != 0)
			{
				if (gotUseInterpolation.Enabled)
				{
					gotUseInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					gotUseInterpolation.Timestep = timestep;
				}
				else
				{
					_gotUse = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_gotUse(timestep);
				}
			}
			if ((0x8 & readDirtyFlags[0]) != 0)
			{
				if (canDisableInterpolation.Enabled)
				{
					canDisableInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					canDisableInterpolation.Timestep = timestep;
				}
				else
				{
					_canDisable = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_canDisable(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (positionInterpolation.Enabled && !positionInterpolation.current.UnityNear(positionInterpolation.target, 0.0015f))
			{
				_position = (Vector3)positionInterpolation.Interpolate();
				//RunChange_position(positionInterpolation.Timestep);
			}
			if (rotationInterpolation.Enabled && !rotationInterpolation.current.UnityNear(rotationInterpolation.target, 0.0015f))
			{
				_rotation = (Quaternion)rotationInterpolation.Interpolate();
				//RunChange_rotation(rotationInterpolation.Timestep);
			}
			if (gotUseInterpolation.Enabled && !gotUseInterpolation.current.UnityNear(gotUseInterpolation.target, 0.0015f))
			{
				_gotUse = (bool)gotUseInterpolation.Interpolate();
				//RunChange_gotUse(gotUseInterpolation.Timestep);
			}
			if (canDisableInterpolation.Enabled && !canDisableInterpolation.current.UnityNear(canDisableInterpolation.target, 0.0015f))
			{
				_canDisable = (bool)canDisableInterpolation.Interpolate();
				//RunChange_canDisable(canDisableInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public HealthPotNetworkObject() : base() { Initialize(); }
		public HealthPotNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public HealthPotNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
