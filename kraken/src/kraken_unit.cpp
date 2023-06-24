// kraken_unit.cpp

// 对应头文件
#include "kraken_unit.h"

namespace kraken
{
	reference_frame::reference_frame(const reference_frame& parent, vec3 position, vec3 velocity, vec3 ang_velocity, quaternion rotation)
	{

	}

	reference_frame::reference_frame(vec3 position, vec3 velocity, vec3 ang_velocity, quaternion rotation)
	{

	}

	reference_frame reference_frame::to_ref_frame(const reference_frame& prev_ref)
	{

	}

	reference_frame reference_frame::relative(const reference_frame& rel, const reference_frame& abs)
	{

	}

	relative_vector relative_vector::to_ref_frame(const reference_frame& ref)
	{

	}
}