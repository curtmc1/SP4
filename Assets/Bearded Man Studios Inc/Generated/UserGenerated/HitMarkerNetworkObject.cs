using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0]")]
	public partial class HitMarkerNetworkObject : NetworkObject
	{
		public const int IDENTITY = 16;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private bool _show;
		public event FieldEvent<bool> showChanged;
		public Interpolated<bool> showInterpolation = new Interpolated<bool>() { LerpT = 0f, Enabled = false };
		public bool show
		{
			get { return _show; }
			set
			{
				// Don't do anything if the value is the same
				if (_show == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_show = value;
				hasDirtyFields = true;
			}
		}

		public void SetshowDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_show(ulong timestep)
		{
			if (showChanged != null) showChanged(_show, timestep);
			if (fieldAltered != null) fieldAltered("show", _show, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			showInterpolation.current = showInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _show);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_show = UnityObjectMapper.Instance.Map<bool>(payload);
			showInterpolation.current = _show;
			showInterpolation.target = _show;
			RunChange_show(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _show);

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
				if (showInterpolation.Enabled)
				{
					showInterpolation.target = UnityObjectMapper.Instance.Map<bool>(data);
					showInterpolation.Timestep = timestep;
				}
				else
				{
					_show = UnityObjectMapper.Instance.Map<bool>(data);
					RunChange_show(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (showInterpolation.Enabled && !showInterpolation.current.UnityNear(showInterpolation.target, 0.0015f))
			{
				_show = (bool)showInterpolation.Interpolate();
				//RunChange_show(showInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public HitMarkerNetworkObject() : base() { Initialize(); }
		public HitMarkerNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public HitMarkerNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
