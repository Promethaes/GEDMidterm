#include "Wrapper.h"

CheckpointTimeLogger checkpoint;

PLUGIN_API void ResetLogger()
{
	return checkpoint.ResetLogger();
}

PLUGIN_API void SaveCheckpointTime(float RTBC)
{
	checkpoint.SaveCheckpointTime(RTBC);
}

PLUGIN_API float GetTotalTime()
{
	return checkpoint.GetTotalTime();
}

PLUGIN_API float GetCheckpointTime(int index)
{
	return checkpoint.GetCheckpointTime(index);
}

int GetNumCheckpoints()
{
	return checkpoint.GetNumCheckpoints();
}
