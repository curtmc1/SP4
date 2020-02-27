using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0.15,0.15,0,0,0,0,0.15,0.15]")]
	public partial class AINetworkObject : NetworkObject
	{
		public const int IDENTITY = 1;

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
		private int _health;
		public event FieldEvent<int> healthChanged;
		public Interpolated<int> healthInterpolation = new Interpolated<int>() { LerpT = 0f, Enabled = false };
		public int health
		{
			get { return _health; }
			set
			{
				// Don't do anything if the value is the same
				if (_health == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x4;
				_health = value;
				hasDirtyFields = true;
			}
		}

		public void SethealthDirty()
		{
			_dirtyFields[0] |= 0x4;
			hasDirtyFields = true;
		}

		private void RunChange_health(ulong timestep)
		{
			if (healthChanged != null) healthChanged(_health, timestep);
			if (fieldAltered != null) fieldAltered("health", _health, timestep);
		}
		[ForgeGeneratedField]
		private bool _dead;
		public event FieldEvent<bool> deadChanged;
		public Interpolated<bool> deadInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool dead
		{
			get { return _dead; }
			set
			{
				// Don't do anything if the value is the same
				if (_dead == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x8;
				_dead = value;
				hasDirtyFields = true;
			}
		}

		public void SetdeadDirty()
		{
			_dirtyFields[0] |= 0x8;
			hasDirtyFields = true;
		}

		private void RunChange_dead(ulong timestep)
		{
			if (deadChanged != null) deadChanged(_dead, timestep);
			if (fieldAltered != null) fieldAltered("dead", _dead, timestep);
		}
		[ForgeGeneratedField]
		private float _invisibleCoolDown;
		public event FieldEvent<float> invisibleCoolDownChanged;
		public InterpolateFloat invisibleCoolDownInterpolation = new InterpolateFloat() { LerpT = 0f, Enabled = false };
		public float invisibleCoolDown
		{
			get { return _invisibleCoolDown; }
			set
			{
				// Don't do anything if the value is the same
				if (_invisibleCoolDown == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x10;
				_invisibleCoolDown = value;
				hasDirtyFields = true;
			}
		}

		public void SetinvisibleCoolDownDirty()
		{
			_dirtyFields[0] |= 0x10;
			hasDirtyFields = true;
		}

		private void RunChange_invisibleCoolDown(ulong timestep)
		{
			if (invisibleCoolDownChanged != null) invisibleCoolDownChanged(_invisibleCoolDown, timestep);
			if (fieldAltered != null) fieldAltered("invisibleCoolDown", _invisibleCoolDown, timestep);
		}
		[ForgeGeneratedField]
		private bool _invisible;
		public event FieldEvent<bool> invisibleChanged;
		public Interpolated<bool> invisibleInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool invisible
		{
			get { return _invisible; }
			set
			{
				// Don't do anything if the value is the same
				if (_invisible == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x20;
				_invisible = value;
				hasDirtyFields = true;
			}
		}

		public void SetinvisibleDirty()
		{
			_dirtyFields[0] |= 0x20;
			hasDirtyFields = true;
		}

		private void RunChange_invisible(ulong timestep)
		{
			if (invisibleChanged != null) invisibleChanged(_invisible, timestep);
			if (fieldAltered != null) fieldAltered("invisible", _invisible, timestep);
		}
		[ForgeGeneratedField]
		private float _distanceaway;
		public event FieldEvent<float> distanceawayChanged;
		public InterpolateFloat distanceawayInterpolation = new InterpolateFloat() { LerpT = 0.15f, Enabled = true };
		public float distanceaway
		{
			get { return _distanceaway; }
			set
			{
				// Don't do anything if the value is the same
				if (_distanceaway == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x40;
				_distanceaway = value;
				hasDirtyFields = true;
			}
		}

		public void SetdistanceawayDirty()
		{
			_dirtyFields[0] |= 0x40;
			hasDirtyFields = true;
		}

		private void RunChange_distanceaway(ulong timestep)
		{
			if (distanceawayChanged != null) distanceawayChanged(_distanceaway, timestep);
			if (fieldAltered != null) fieldAltered("distanceaway", _distanceaway, timestep);
		}
		[ForgeGeneratedField]
		private float _range;
		public event FieldEvent<float> rangeChanged;
		public InterpolateFloat rangeInterpolation = new InterpolateFloat() { LerpT = 0.15f, Enabled = true };
		public float range
		{
			get { return _range; }
			set
			{
				// Don't do anything if the value is the same
				if (_range == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x80;
				_range = value;
				hasDirtyFields = true;
			}
		}

		public void SetrangeDirty()
		{
			_dirtyFields[0] |= 0x80;
			hasDirtyFields = true;
		}

		private void RunChange_range(ulong timestep)
		{
			if (rangeChanged != null) rangeChanged(_range, timestep);
			if (fieldAltered != null) fieldAltered("range", _range, timestep);
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
			healthInterpolation.current = healthInterpolation.target;
			deadInterpolation.current = deadInterpolation.target;
			invisibleCoolDownInterpolation.current = invisibleCoolDownInterpolation.target;
			invisibleInterpolation.current = invisibleInterpolation.target;
			distanceawayInterpolation.current = distanceawayInterpolation.target;
			rangeInterpolation.current = rangeInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _position);
			UnityObjectMapper.Instance.MapBytes(data, _rotation);
			UnityObjectMapper.Instance.MapBytes(data, _health);
			UnityObjectMapper.Instance.MapBytes(data, _dead);
			UnityObjectMapper.Instance.MapBytes(data, _invisibleCoolDown);
			UnityObjectMapper.Instance.MapBytes(data, _invisible);
			UnityObjectMapper.Instance.MapBytes(data, _distanceaway);
			UnityObjectMapper.Instance.MapBytes(data, _range);

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
			_health = UnityObjectMapper.Instance.Map<int>(payload);
			healthInterpolation.current = _health;
			healthInterpolation.target = _health;
			RunChange_health(timestep);
			_dead = UnityObjectMapper.Instance.Map<bool>(payload);
			deadInterpolation.current = _dead;
			deadInterpolation.target = _dead;
			RunChange_dead(timestep);
			_invisibleCoolDown = UnityObjectMapper.Instance.Map<float>(payload);
			invisibleCoolDownInterpolation.current = _invisibleCoolDown;
			invisibleCoolDownInterpolation.target = _invisibleCoolDown;
			RunChange_invisibleCoolDown(timestep);
			_invisible = UnityObjectMapper.Instance.Map<bool>(payload);
			invisibleInterpolation.current = _invisible;
			invisibleInterpolation.target = _invisible;
			RunChange_invisible(timestep);
			_distanceaway = UnityObjectMapper.Instance.Map<float>(payload);
			distanceawayInterpolation.current = _distanceaway;
			distanceawayInterpolation.target = _distanceaway;
			RunChange_distanceaway(timestep);
			_range = UnityObjectMapper.Instance.Map<float>(payload);
			rangeInterpolation.current = _range;
			rangeInterpolation.target = _range;
			RunChange_range(timestep);
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
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _health);
			if ((0x8 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _dead);
			if ((0x10 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _invisibleCoolDown);
			if ((0x20 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _invisible);
			if ((0x40 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _distanceaway);
			if ((0x80 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _range);

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
				if (healthInterpolation.Enabled)
				{
					healthInterpolation.target = UnityObjectMapper.Instance.Map<int>(data);
					healthInterpolation.Timestep = timestep;
				}
				else
				{
					_health = UnityObjectMapper.Instance.Map<int>(data);
					RunChange_health(timestep);
				}
			}
			if ((0x8 & readDirtyFlags[0]) != 0)
			{
				if (deadInterpolation.Enabled)
				{
					deadInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					deadInterpolation.Timestep = timestep;
				}
				else
				{
					_dead = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_dead(timestep);
				}
			}
			if ((0x10 & readDirtyFlags[0]) != 0)
			{
				if (invisibleCoolDownInterpolation.Enabled)
				{
					invisibleCoolDownInterpolation.target = UnityObjectMapper.Instance.Map<float>(data);
					invisibleCoolDownInterpolation.Timestep = timestep;
				}
				else
				{
					_invisibleCoolDown = UnityObjectMapper.Instance.Map<float>(data);
					RunChange_invisibleCoolDown(timestep);
				}
			}
			if ((0x20 & readDirtyFlags[0]) != 0)
			{
				if (invisibleInterpolation.Enabled)
				{
					invisibleInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					invisibleInterpolation.Timestep = timestep;
				}
				else
				{
					_invisible = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_invisible(timestep);
				}
			}
			if ((0x40 & readDirtyFlags[0]) != 0)
			{
				if (distanceawayInterpolation.Enabled)
				{
					distanceawayInterpolation.target = UnityObjectMapper.Instance.Map<float>(data);
					distanceawayInterpolation.Timestep = timestep;
				}
				else
				{
					_distanceaway = UnityObjectMapper.Instance.Map<float>(data);
					RunChange_distanceaway(timestep);
				}
			}
			if ((0x80 & readDirtyFlags[0]) != 0)
			{
				if (rangeInterpolation.Enabled)
				{
					rangeInterpolation.target = UnityObjectMapper.Instance.Map<float>(data);
					rangeInterpolation.Timestep = timestep;
				}
				else
				{
					_range = UnityObjectMapper.Instance.Map<float>(data);
					RunChange_range(timestep);
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
			if (healthInterpolation.Enabled && !healthInterpolation.current.UnityNear(healthInterpolation.target, 0.0015f))
			{
				_health = (int)healthInterpolation.Interpolate();
				//RunChange_health(healthInterpolation.Timestep);
			}
			if (deadInterpolation.Enabled && !deadInterpolation.current.UnityNear(deadInterpolation.target, 0.0015f))
			{
				_dead = (bool)deadInterpolation.Interpolate();
				//RunChange_dead(deadInterpolation.Timestep);
			}
			if (invisibleCoolDownInterpolation.Enabled && !invisibleCoolDownInterpolation.current.UnityNear(invisibleCoolDownInterpolation.target, 0.0015f))
			{
				_invisibleCoolDown = (float)invisibleCoolDownInterpolation.Interpolate();
				//RunChange_invisibleCoolDown(invisibleCoolDownInterpolation.Timestep);
			}
			if (invisibleInterpolation.Enabled && !invisibleInterpolation.current.UnityNear(invisibleInterpolation.target, 0.0015f))
			{
				_invisible = (bool)invisibleInterpolation.Interpolate();
				//RunChange_invisible(invisibleInterpolation.Timestep);
			}
			if (distanceawayInterpolation.Enabled && !distanceawayInterpolation.current.UnityNear(distanceawayInterpolation.target, 0.0015f))
			{
				_distanceaway = (float)distanceawayInterpolation.Interpolate();
				//RunChange_distanceaway(distanceawayInterpolation.Timestep);
			}
			if (rangeInterpolation.Enabled && !rangeInterpolation.current.UnityNear(rangeInterpolation.target, 0.0015f))
			{
				_range = (float)rangeInterpolation.Interpolate();
				//RunChange_range(rangeInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public AINetworkObject() : base() { Initialize(); }
		public AINetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public AINetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
