﻿using System;
using System.Collections.Generic;
using System.Text;

public interface ICar
{
    string Model { get; set; }
    string Driver { get; set; }

    string PushGasPedal();
    string PushBrakes();
}
