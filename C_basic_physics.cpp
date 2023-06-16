#include "C_basic_physics.h"
#include <math.h>

double C_basic_physics::vis_via_Eq(bool b_v, float f_v, bool b_u, float f_u, bool b_r, float f_r, bool b_a, float f_a)
{
    if (b_v + b_u + b_r + b_a == 3&& f_v>0&& f_u > 0 && f_r > 0 && f_a > 0 ) {
        if (b_v != 0) {
            if (b_u != 0) {
                if (b_r != 0) {
                    f_a = 1 / (2 / f_r - (f_v * f_v / f_u));
                    return f_a;
                }
                else
                {
                    f_r = 2 / (1 / f_a + (f_v * f_v / f_u));
                    return f_r;
                }
            }
            else {
                f_u = f_v * f_v / ((2 / f_r) - (1 / f_a));
                return f_u;
            }
        }
        else
        {
            f_v = sqrt(f_u * ((2 / f_r) - (1 / f_a)));
            return f_v;
        }
        
    }
    else
    {
        return -1;
    }
    return 0.0;
}
