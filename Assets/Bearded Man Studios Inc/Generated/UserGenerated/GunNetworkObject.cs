using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0.15,0.15,0,0,0,0,0,0]")]
	public partial class GunNetworkObject : NetworkObject
	{
		public const int IDENTITY = 14;

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
		private int _gunChoice;
		public event FieldEvent<int> gunChoiceChanged;
		public Interpolated<int> gunChoiceInterpolation = new Interpolated<int>() { LerpT = 0f, Enabled = false };
		public int gunChoice
		{
			get { return _gunChoice; }
			set
			{
				// Don't do anything if the value is the same
				if (_gunChoice == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x4;
				_gunChoice = value;
				hasDirtyFields = true;
			}
		}

		public void SetgunChoiceDirty()
		{
			_dirtyFields[0] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_gunChoice(ulong timestep)
		{
			if (gunChoiceChanged != null) gunChoiceChanged(_gunChoice, timestep);
			if (fieldAltered != null) fieldAltered("gunChoice", _gunChoice, timestep);
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
				_dirtyFields[0] |= 0x8;
				_hasShot = value;
				hasDirtyFields = true;
			}
		}

		public void SethasShotDirty()
		{
			_dirtyFields[0] |= 0x8;
			hasDirtyFields = true;
		}

		private void RunChange_hasShot(ulong timestep)
		{
			if (hasShotChanged != null) hasShotChanged(_hasShot, timestep);
			if (fieldAltered != null) fieldAltered("hasShot", _hasShot, timestep);
		}
		[ForgeGeneratedField]
		private bool _p1HasShot;
		public event FieldEvent<bool> p1HasShotChanged;
		public Interpolated<bool> p1HasShotInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool p1HasShot
		{
			get { return _p1HasShot; }
			set
			{
				// Don't do anything if the value is the same
				if (_p1HasShot == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x10;
				_p1HasShot = value;
				hasDirtyFields = true;
			}
		}

		public void Setp1HasShotDirty()
		{
			_dirtyFields[0] |= 0x10;
			hasDirtyFields = true;
		}

		private void RunChange_p1HasShot(ulong timestep)
		{
			if (p1HasShotChanged != null) p1HasShotChanged(_p1HasShot, timestep);
			if (fieldAltered != null) fieldAltered("p1HasShot", _p1HasShot, timestep);
		}
		[ForgeGeneratedField]
		private bool _p2HasShot;
		public event FieldEvent<bool> p2HasShotChanged;
		public Interpolated<bool> p2HasShotInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool p2HasShot
		{
			get { return _p2HasShot; }
			set
			{
				// Don't do anything if the value is the same
				if (_p2HasShot == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x20;
				_p2HasShot = value;
				hasDirtyFields = true;
			}
		}

		public void Setp2HasShotDirty()
		{
			_dirtyFields[0] |= 0x20;
			hasDirtyFields = true;
		}

		private void RunChange_p2HasShot(ulong timestep)
		{
			if (p2HasShotChanged != null) p2HasShotChanged(_p2HasShot, timestep);
			if (fieldAltered != null) fieldAltered("p2HasShot", _p2HasShot, timestep);
		}
		[ForgeGeneratedField]
		private Vector3 _portPosition;
		public event FieldEvent<Vector3> portPositionChanged;
		public InterpolateVector3 portPositionInterpolation = new InterpolateVector3() { LerpT = 0f, Enabled = false };
		public Vector3 portPosition
		{
			get { return _portPosition; }
			set
			{
				// Don't do anything if the value is the same
				if (_portPosition == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x40;
				_portPosition = value;
				hasDirtyFields = true;
			}
		}

		public void SetportPositionDirty()
		{
			_dirtyFields[0] |= 0x40;
			hasDirtyFields = true;
		}

		private void RunChange_portPosition(ulong timestep)
		{
			if (portPositionChanged != null) portPositionChanged(_portPosition, timestep);
			if (fieldAltered != null) fieldAltered("portPosition", _portPosition, timestep);
		}
		[ForgeGeneratedField]
		private Quaternion _portRotation;
		public event FieldEvent<Quaternion> portRotationChanged;
		public InterpolateQuaternion portRotationInterpolation = new InterpolateQuaternion() { LerpT = 0f, Enabled = false };
		public Quaternion portRotation
		{
			get { return _portRotation; }
			set
			{
				// Don't do anything if the value is the same
				if (_portRotation == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x80;
				_portRotation = value;
				hasDirtyFields = true;
			}
		}

		public void SetportRotationDirty()
		{
			_dirtyFields[0] |= 0x80;
			hasDirtyFields = true;
		}

		private void RunChange_portRotation(ulong timestep)
		{
			if (portRotationChanged != null) portRotationChanged(_portRotation, timestep);
			if (fieldAltered != null) fieldAltered("portRotation", _portRotation, timestep);
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
			gunChoiceInterpolation.current = gunChoiceInterpolation.target;
			hasShotInterpolation.current = hasShotInterpolation.target;
			p1HasShotInterpolation.current = p1HasShotInterpolation.target;
			p2HasShotInterpolation.current = p2HasShotInterpolation.target;
			portPositionInterpolation.current = portPositionInterpolation.target;
			portRotationInterpolation.current = portRotationInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _position);
			UnityObjectMapper.Instance.MapBytes(data, _rotation);
			UnityObjectMapper.Instance.MapBytes(data, _gunChoice);
			UnityObjectMapper.Instance.MapBytes(data, _hasShot);
			UnityObjectMapper.Instance.MapBytes(data, _p1HasShot);
			UnityObjectMapper.Instance.MapBytes(data, _p2HasShot);
			UnityObjectMapper.Instance.MapBytes(data, _portPosition);
			UnityObjectMapper.Instance.MapBytes(data, _portRotation);

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
			_gunChoice = UnityObjectMapper.Instance.Map<int>(payload);
			gunChoiceInterpolation.current = _gunChoice;
			gunChoiceInterpolation.target = _gunChoice;
			RunChange_gunChoice(timestep);
			_hasShot = UnityObjectMapper.Instance.Map<bool>(payload);
			hasShotInterpolation.current = _hasShot;
			hasShotInterpolation.target = _hasShot;
			RunChange_hasShot(timestep);
			_p1HasShot = UnityObjectMapper.Instance.Map<bool>(payload);
			p1HasShotInterpolation.current = _p1HasShot;
			p1HasShotInterpolation.target = _p1HasShot;
			RunChange_p1HasShot(timestep);
			_p2HasShot = UnityObjectMapper.Instance.Map<bool>(payload);
			p2HasShotInterpolation.current = _p2HasShot;
			p2HasShotInterpolation.target = _p2HasShot;
			RunChange_p2HasShot(timestep);
			_portPosition = UnityObjectMapper.Instance.Map<Vector3>(payload);
			portPositionInterpolation.current = _portPosition;
			portPositionInterpolation.target = _portPosition;
			RunChange_portPosition(timestep);
			_portRotation = UnityObjectMapper.Instance.Map<Quaternion>(payload);
			portRotationInterpolation.current = _portRotation;
			portRotationInterpolation.target = _portRotation;
			RunChange_portRotation(timestep);
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
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _gunChoice);
			if ((0x8 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _hasShot);
			if ((0x10 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _p1HasShot);
			if ((0x20 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _p2HasShot);
			if ((0x40 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _portPosition);
			if ((0x80 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _portRotation);

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
				if (gunChoiceInterpolation.Enabled)
				{
					gunChoiceInterpolation.target = UnityObjectMapper.Instance.Map<int>(data);
					gunChoiceInterpolation.Timestep = timestep;
				}
				else
				{
					_gunChoice = UnityObjectMapper.Instance.Map<int>(data);
					RunChange_gunChoice(timestep);
				}
			}
			if ((0x8 & readDirtyFlags[0]) != 0)
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
			if ((0x10 & readDirtyFlags[0]) != 0)
			{
				if (p1HasShotInterpolation.Enabled)
				{
					p1HasShotInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					p1HasShotInterpolation.Timestep = timestep;
				}
				else
				{
					_p1HasShot = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_p1HasShot(timestep);
				}
			}
			if ((0x20 & readDirtyFlags[0]) != 0)
			{
				if (p2HasShotInterpolation.Enabled)
				{
					p2HasShotInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					p2HasShotInterpolation.Timestep = timestep;
				}
				else
				{
					_p2HasShot = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_p2HasShot(timestep);
				}
			}
			if ((0x40 & readDirtyFlags[0]) != 0)
			{
				if (portPositionInterpolation.Enabled)
				{
					portPositionInterpolation.target = UnityObjectMapper.Instance.Map<Vector3>(data);
					portPositionInterpolation.Timestep = timestep;
				}
				else
				{
					_portPosition = UnityObjectMapper.Instance.Map<Vector3>(data);
					RunChange_portPosition(timestep);
				}
			}
			if ((0x80 & readDirtyFlags[0]) != 0)
			{
				if (portRotationInterpolation.Enabled)
				{
					portRotationInterpolation.target = UnityObjectMapper.Instance.Map<Quaternion>(data);
					portRotationInterpolation.Timestep = timestep;
				}
				else
				{
					_portRotation = UnityObjectMapper.Instance.Map<Quaternion>(data);
					RunChange_portRotation(timestep);
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
			if (gunChoiceInterpolation.Enabled && !gunChoiceInterpolation.current.UnityNear(gunChoiceInterpolation.target, 0.0015f))
			{
				_gunChoice = (int)gunChoiceInterpolation.Interpolate();
				//RunChange_gunChoice(gunChoiceInterpolation.Timestep);
			}
			if (hasShotInterpolation.Enabled && !hasShotInterpolation.current.UnityNear(hasShotInterpolation.target, 0.0015f))
			{
				_hasShot = (bool)hasShotInterpolation.Interpolate();
				//RunChange_hasShot(hasShotInterpolation.Timestep);
			}
			if (p1HasShotInterpolation.Enabled && !p1HasShotInterpolation.current.UnityNear(p1HasShotInterpolation.target, 0.0015f))
			{
				_p1HasShot = (bool)p1HasShotInterpolation.Interpolate();
				//RunChange_p1HasShot(p1HasShotInterpolation.Timestep);
			}
			if (p2HasShotInterpolation.Enabled && !p2HasShotInterpolation.current.UnityNear(p2HasShotInterpolation.target, 0.0015f))
			{
				_p2HasShot = (bool)p2HasShotInterpolation.Interpolate();
				//RunChange_p2HasShot(p2HasShotInterpolation.Timestep);
			}
			if (portPositionInterpolation.Enabled && !portPositionInterpolation.current.UnityNear(portPositionInterpolation.target, 0.0015f))
			{
				_portPosition = (Vector3)portPositionInterpolation.Interpolate();
				//RunChange_portPosition(portPositionInterpolation.Timestep);
			}
			if (portRotationInterpolation.Enabled && !portRotationInterpolation.current.UnityNear(portRotationInterpolation.target, 0.0015f))
			{
				_portRotation = (Quaternion)portRotationInterpolation.Interpolate();
				//RunChange_portRotation(portRotationInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public GunNetworkObject() : base() { Initialize(); }
		public GunNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public GunNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
