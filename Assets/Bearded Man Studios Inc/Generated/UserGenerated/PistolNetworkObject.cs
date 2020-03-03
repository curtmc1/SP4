using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0.01,0.01,0,0.01,0.01]")]
	public partial class PistolNetworkObject : NetworkObject
	{
		public const int IDENTITY = 20;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private Vector3 _position;
		public event FieldEvent<Vector3> positionChanged;
		public InterpolateVector3 positionInterpolation = new InterpolateVector3() { LerpT = 0.01f, Enabled = true };
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
		public InterpolateQuaternion rotationInterpolation = new InterpolateQuaternion() { LerpT = 0.01f, Enabled = true };
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
		private bool _hasShot;
		public event FieldEvent<bool> hasShotChanged;
		public Interpolated<bool> hasShotInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool hasShot
		{
			get { return _hasShot; }
			set
			{
				// Don't do anything if the value is the same
				if (_hasShot == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x4;
				_hasShot = value;
				hasDirtyFields = true;
			}
		}

		public void SethasShotDirty()
		{
			_dirtyFields[0] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_hasShot(ulong timestep)
		{
			if (hasShotChanged != null) hasShotChanged(_hasShot, timestep);
			if (fieldAltered != null) fieldAltered("hasShot", _hasShot, timestep);
		}
		[ForgeGeneratedField]
		private Vector3 _bulletPosition;
		public event FieldEvent<Vector3> bulletPositionChanged;
		public InterpolateVector3 bulletPositionInterpolation = new InterpolateVector3() { LerpT = 0.01f, Enabled = true };
		public Vector3 bulletPosition
		{
			get { return _bulletPosition; }
			set
			{
				// Don't do anything if the value is the same
				if (_bulletPosition == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x8;
				_bulletPosition = value;
				hasDirtyFields = true;
			}
		}

		public void SetbulletPositionDirty()
		{
			_dirtyFields[0] |= 0x8;
			hasDirtyFields = true;
		}

		private void RunChange_bulletPosition(ulong timestep)
		{
			if (bulletPositionChanged != null) bulletPositionChanged(_bulletPosition, timestep);
			if (fieldAltered != null) fieldAltered("bulletPosition", _bulletPosition, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _bulletRotation;
		public event FieldEvent<Quaternion> bulletRotationChanged;
		public InterpolateQuaternion bulletRotationInterpolation = new InterpolateQuaternion() { LerpT = 0.01f, Enabled = true };
		public Quaternion bulletRotation
		{
			get { return _bulletRotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_bulletRotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x10;
				_bulletRotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetbulletRotationDirty()
		{
			_dirtyFields[0] |= 0x10;
			hasDirtyFields = true;
		}

		private void RunChange_bulletRotation(ulong timestep)
		{
			if (bulletRotationChanged != null) bulletRotationChanged(_bulletRotation, timestep);
			if (fieldAltered != null) fieldAltered("bulletRotation", _bulletRotation, timestep);
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
			hasShotInterpolation.current = hasShotInterpolation.target;
			bulletPositionInterpolation.current = bulletPositionInterpolation.target;
			bulletRotationInterpolation.current = bulletRotationInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _position);
			UnityObjectMapper.Instance.MapBytes(data, _rotation);
			UnityObjectMapper.Instance.MapBytes(data, _hasShot);
			UnityObjectMapper.Instance.MapBytes(data, _bulletPosition);
			UnityObjectMapper.Instance.MapBytes(data, _bulletRotation);

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
			_hasShot = UnityObjectMapper.Instance.Map<bool>(payload);
			hasShotInterpolation.current = _hasShot;
			hasShotInterpolation.target = _hasShot;
			RunChange_hasShot(timestep);
			_bulletPosition = UnityObjectMapper.Instance.Map<Vector3>(payload);
			bulletPositionInterpolation.current = _bulletPosition;
			bulletPositionInterpolation.target = _bulletPosition;
			RunChange_bulletPosition(timestep);
			_bulletRotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			bulletRotationInterpolation.current = _bulletRotation;
			bulletRotationInterpolation.target = _bulletRotation;
			RunChange_bulletRotation(timestep);
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
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _hasShot);
			if ((0x8 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _bulletPosition);
			if ((0x10 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _bulletRotation);

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
				if (hasShotInterpolation.Enabled)
				{
					hasShotInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					hasShotInterpolation.Timestep = timestep;
				}
				else
				{
					_hasShot = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_hasShot(timestep);
				}
			}
			if ((0x8 & readDirtyFlags[0]) != 0)
			{
				if (bulletPositionInterpolation.Enabled)
				{
					bulletPositionInterpolation.target = UnityObjectMapper.Instance.Map<Vector3>(data);
					bulletPositionInterpolation.Timestep = timestep;
				}
				else
				{
					_bulletPosition = UnityObjectMapper.Instance.Map<Vector3>(data);
					RunChange_bulletPosition(timestep);
				}
			}
			if ((0x10 & readDirtyFlags[0]) != 0)
			{
				if (bulletRotationInterpolation.Enabled)
				{
					bulletRotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					bulletRotationInterpolation.Timestep = timestep;
				}
				else
				{
					_bulletRotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_bulletRotation(timestep);
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
			if (hasShotInterpolation.Enabled && !hasShotInterpolation.current.UnityNear(hasShotInterpolation.target, 0.0015f))
			{
				_hasShot = (bool)hasShotInterpolation.Interpolate();
				//RunChange_hasShot(hasShotInterpolation.Timestep);
			}
			if (bulletPositionInterpolation.Enabled && !bulletPositionInterpolation.current.UnityNear(bulletPositionInterpolation.target, 0.0015f))
			{
				_bulletPosition = (Vector3)bulletPositionInterpolation.Interpolate();
				//RunChange_bulletPosition(bulletPositionInterpolation.Timestep);
			}
			if (bulletRotationInterpolation.Enabled && !bulletRotationInterpolation.current.UnityNear(bulletRotationInterpolation.target, 0.0015f))
			{
				_bulletRotation = (Quaternion)bulletRotationInterpolation.Interpolate();
				//RunChange_bulletRotation(bulletRotationInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public PistolNetworkObject() : base() { Initialize(); }
		public PistolNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public PistolNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
