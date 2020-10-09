#pragma once

#include "CheckpointTimeLogger.h"

#ifdef __cplusplus

extern "C" {
#endif

	//put your functions here
	PLUGIN_API void ResetLogger();

	//save most recent checkpoint time
	PLUGIN_API void SaveCheckpointTime(float RTBC);

	//get total time for race
	PLUGIN_API float GetTotalTime();

	//get time at index
	PLUGIN_API float GetCheckpointTime(int index);

	//get num checkpoints
	PLUGIN_API int GetNumCheckpoints();


#ifdef __cplusplus
}
#endif

class Wrapper
{
};

