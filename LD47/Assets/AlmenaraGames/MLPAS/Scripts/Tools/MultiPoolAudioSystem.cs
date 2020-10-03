using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlmenaraGames{
public class MultiPoolAudioSystem {

		public static bool isNULL=true;
		static MultiAudioManager m_audioManager;
		public static MultiAudioManager audioManager { get{ if (isNULL) {
					m_audioManager = MultiAudioManager.Instance; isNULL = false;
				} return m_audioManager;} set { m_audioManager=value; } }
}
}