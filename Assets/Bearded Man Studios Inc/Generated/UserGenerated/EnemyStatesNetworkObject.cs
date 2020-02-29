using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0,0,0]")]
	public partial class EnemyStatesNetworkObject : NetworkObject
	{
		public const int IDENTITY = 11;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
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
				_dirtyFields[0] |= 0x1;
				_dead = value;
				hasDirtyFields = true;
			}
		}

		public void SetdeadDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_dead(ulong timestep)
		{
			if (deadChanged != null) deadChanged(_dead, timestep);
			if (fieldAltered != null) fieldAltered("dead", _dead, timestep);
		}
		[ForgeGeneratedField]
		private float _distanceAway;
		public event FieldEvent<float> distanceAwayChanged;
		public InterpolateFloat distanceAwayInterpolation = new InterpolateFloat() { LerpT = 0f, Enabled = false };
		public float distanceAway
		{
			get { return _distanceAway; }
			set
			{
				// Don't do anything if the value is the same
				if (_distanceAway == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x2;
				_distanceAway = value;
				hasDirtyFields = true;
			}
		}

		public void SetdistanceAwayDirty()
		{
			_dirtyFields[0] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_distanceAway(ulong timestep)
		{
			if (distanceAwayChanged != null) distanceAwayChanged(_distanceAway, timestep);
			if (fieldAltered != null) fieldAltered("distanceAway", _distanceAway, timestep);
		}
		[ForgeGeneratedField]
		private float _range;
		public event FieldEvent<float> rangeChanged;
		public InterpolateFloat rangeInterpolation = new InterpolateFloat() { LerpT = 0f, Enabled = false };
		public float range
		{
			get { return _range; }
			set
			{
				// Don't do anything if the value is the same
				if (_range == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x4;
				_range = value;
				hasDirtyFields = true;
			}
		}

		public void SetrangeDirty()
		{
			_dirtyFields[0] |= 0x4;
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
			deadInterpolation.current = deadInterpolation.target;
			distanceAwayInterpolation.current = distanceAwayInterpolation.target;
			rangeInterpolation.current = rangeInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _dead);
			UnityObjectMapper.Instance.MapBytes(data, _distanceAway);
			UnityObjectMapper.Instance.MapBytes(data, _range);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_dead = UnityObjectMapper.Instance.Map<bool>(payload);
			deadInterpolation.current = _dead;
			deadInterpolation.target = _dead;
			RunChange_dead(timestep);
			_distanceAway = UnityObjectMapper.Instance.Map<float>(payload);
			distanceAwayInterpolation.current = _distanceAway;
			distanceAwayInterpolation.target = _distanceAway;
			RunChange_distanceAway(timestep);
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
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _dead);
			if ((0x2 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _distanceAway);
			if ((0x4 & _dirtyFields[0]) != 0)
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
			if ((0x2 & readDirtyFlags[0]) != 0)
			{
				if (distanceAwayInterpolation.Enabled)
				{
					distanceAwayInterpolation.target = UnityObjectMapper.Instance.Map<float>(data);
					distanceAwayInterpolation.Timestep = timestep;
				}
				else
				{
					_distanceAway = UnityObjectMapper.Instance.Map<float>(data);
					RunChange_distanceAway(timestep);
				}
			}
			if ((0x4 & readDirtyFlags[0]) != 0)
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

			if (deadInterpolation.Enabled && !deadInterpolation.current.UnityNear(deadInterpolation.target, 0.0015f))
			{
				_dead = (bool)deadInterpolation.Interpolate();
				//RunChange_dead(deadInterpolation.Timestep);
			}
			if (distanceAwayInterpolation.Enabled && !distanceAwayInterpolation.current.UnityNear(distanceAwayInterpolation.target, 0.0015f))
			{
				_distanceAway = (float)distanceAwayInterpolation.Interpolate();
				//RunChange_distanceAway(distanceAwayInterpolation.Timestep);
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

		public EnemyStatesNetworkObject() : base() { Initialize(); }
		public EnemyStatesNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public EnemyStatesNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
