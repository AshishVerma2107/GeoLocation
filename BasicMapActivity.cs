using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Android.Graphics;
using Android.Support.V4.App;
using System.Threading;
using Java.Util;
using Java.Lang;
using Android.Views.Animations;
using Android.Animation;
using Android.Content.Res;
using Android.Util;

namespace GeoLocation
{


    [Activity(Label = "MyGeoLocation", MainLauncher = true)]
    public class BasicMapActivity : Android.Support.V4.App.FragmentActivity, IOnMapReadyCallback
    {
        private GoogleMap mMap;
        public Marker myMarker, mCarMarker, myRedCarMarkar, mSecondcarMarker;
        Handler handler, handler1;
        // Action action;
        Action myAction1, action1, myAction2, action2;
        public Bitmap mMarkerIcon, mRedCarMarkerIcon, mSecondcar, mMarkerIcon1;
        private List<LatLng> mPathPolygonPoints = new List<LatLng>();
        private List<LatLng> mPathPolygonPointsSecond = new List<LatLng>();

        private List<LatLng> mRedCarlatlongPoints = new List<LatLng>();
        float MOVE_ANIMATION_DURATION = 1000;
        float MOVE_ANIMATION_DURATION1 = 2000;
        float TURN_ANIMATION_DURATION = 1000;
        float TURN_ANIMATION_DURATION1 = 2000;
        public int mIndexCurrentPoint = 0;
        public int mIndexCurrentPoint1 = 0;
        int sizeoflist, sizeoflist1;
        int countseconds;

        ObjectAnimator animation1;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.basic_demo);
            SupportMapFragment mapFragment = (SupportMapFragment)SupportFragmentManager
              .FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
            addLatLong();
           // addRedCarLatLong();
            SecondCar();
           


        }
    
       
        
        //private void addRedCarLatLong()
        //{
        //    mRedCarlatlongPoints.Add(new LatLng(26.8612, 80.9864));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8613, 80.9875));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8614, 80.9876));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8615, 80.9877));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8616, 80.9878));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8617, 80.9879));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8618, 80.9880));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8619, 80.9881));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8620, 80.9882));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8614, 80.9883));

        //    mRedCarlatlongPoints.Add(new LatLng(26.8630, 80.9884));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8640, 80.9890));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8650, 80.9900));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8660, 80.9910));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8670, 80.9920));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8680, 80.9930));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8690, 80.9940));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8700, 80.9950));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8710, 80.9960));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8720, 80.9970));
        //    mRedCarlatlongPoints.Add(new LatLng(26.8730, 80.9980));

        //}

       
            private void addLatLong()
        {

            mPathPolygonPoints.Add(new LatLng(26.8612, 80.98601));
            mPathPolygonPoints.Add(new LatLng(26.8613, 80.98702));
            mPathPolygonPoints.Add(new LatLng(26.8614, 80.98803));
            mPathPolygonPoints.Add(new LatLng(26.8615, 80.98904));
            mPathPolygonPoints.Add(new LatLng(26.8616, 80.99005));
            mPathPolygonPoints.Add(new LatLng(26.8617, 80.99106));
            mPathPolygonPoints.Add(new LatLng(26.8618, 80.99207));
            mPathPolygonPoints.Add(new LatLng(26.8619, 80.99308));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.99409));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.99510));

            mPathPolygonPoints.Add(new LatLng(26.8612, 80.98601));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.98702));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.98803));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.98904));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.99005));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.99106));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.99207));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.99308));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.99409));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.99510));

            mPathPolygonPoints.Add(new LatLng(26.8612, 80.98601));
            mPathPolygonPoints.Add(new LatLng(26.8613, 80.98702));
            mPathPolygonPoints.Add(new LatLng(26.8614, 80.98803));
            mPathPolygonPoints.Add(new LatLng(26.8615, 80.98904));
            mPathPolygonPoints.Add(new LatLng(26.8616, 80.99005));
            mPathPolygonPoints.Add(new LatLng(26.8617, 80.99106));
            mPathPolygonPoints.Add(new LatLng(26.8618, 80.99207));
            mPathPolygonPoints.Add(new LatLng(26.8619, 80.99308));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.99409));
            mPathPolygonPoints.Add(new LatLng(26.8612, 80.99510));



            //mPathPolygonPoints.Add(new LatLng(22.5792370, 88.426690));
            //mPathPolygonPoints.Add(new LatLng(22.5792380, 88.426700));
            //mPathPolygonPoints.Add(new LatLng(22.5792390, 88.426740));
            //mPathPolygonPoints.Add(new LatLng(22.5792410, 88.426780));
            //mPathPolygonPoints.Add(new LatLng(22.5792420, 88.426820));
            //mPathPolygonPoints.Add(new LatLng(22.5792430, 88.426860));
            //mPathPolygonPoints.Add(new LatLng(22.5792430, 88.426900));
            //mPathPolygonPoints.Add(new LatLng(22.5792430, 88.426940));
            //mPathPolygonPoints.Add(new LatLng(22.5792430, 88.426980));
            //mPathPolygonPoints.Add(new LatLng(22.5792430, 88.427020));
            //mPathPolygonPoints.Add(new LatLng(22.5792430, 88.427060));
            //mPathPolygonPoints.Add(new LatLng(22.5792490, 88.427100));
            //mPathPolygonPoints.Add(new LatLng(22.5792500, 88.426210));
            //mPathPolygonPoints.Add(new LatLng(22.5792510, 88.426320));
            //mPathPolygonPoints.Add(new LatLng(22.5792520, 88.426430));
            //mPathPolygonPoints.Add(new LatLng(22.5792530, 88.426540));
            //mPathPolygonPoints.Add(new LatLng(22.5792540, 88.426650));
            //mPathPolygonPoints.Add(new LatLng(22.5792550, 88.426760));
            //mPathPolygonPoints.Add(new LatLng(22.5792560, 88.426870));
            //mPathPolygonPoints.Add(new LatLng(22.5792570, 88.426880));
            //mPathPolygonPoints.Add(new LatLng(22.5792580, 88.426890));
            //mPathPolygonPoints.Add(new LatLng(22.5792590, 88.426900));
            //mPathPolygonPoints.Add(new LatLng(22.5792600, 88.426910));
            //mPathPolygonPoints.Add(new LatLng(22.5792610, 88.426930));
            //mPathPolygonPoints.Add(new LatLng(22.5792630, 88.426960));
            //mPathPolygonPoints.Add(new LatLng(22.5792650, 88.426990));
            //mPathPolygonPoints.Add(new LatLng(22.5792680, 88.427000));
            //mPathPolygonPoints.Add(new LatLng(22.5792700, 88.4267120));
            //mPathPolygonPoints.Add(new LatLng(22.5792730, 88.4267140));
            //mPathPolygonPoints.Add(new LatLng(22.5792750, 88.4267160));
            //mPathPolygonPoints.Add(new LatLng(22.5792780, 88.4267200));
            //mPathPolygonPoints.Add(new LatLng(22.5792810, 88.4267220));
            //mPathPolygonPoints.Add(new LatLng(22.5792830, 88.4267250));
            //mPathPolygonPoints.Add(new LatLng(22.5792860, 88.4267280));
            //mPathPolygonPoints.Add(new LatLng(22.5792890, 88.4267310));
            //mPathPolygonPoints.Add(new LatLng(22.5792920, 88.4267340));

            //mPathPolygonPoints.Add(new LatLng(23.5792940, 88.4267370));
            //mPathPolygonPoints.Add(new LatLng(22.5792960, 88.4267400));

        }

        private void SecondCar()
        {
            //anim = animation1;
            // animation1 = new ObjectAnimator();
            //animation1.SetDuration(1000);
            //animation1.Start();

            mPathPolygonPointsSecond.Add(new LatLng(26.87171, 80.991061));
            mPathPolygonPointsSecond.Add(new LatLng(26.87182, 80.992062));
            mPathPolygonPointsSecond.Add(new LatLng(26.87193, 80.993063));
            mPathPolygonPointsSecond.Add(new LatLng(26.87204, 80.994064));
            mPathPolygonPointsSecond.Add(new LatLng(26.87215, 80.995065));
            mPathPolygonPointsSecond.Add(new LatLng(26.87226, 80.996066));
            mPathPolygonPointsSecond.Add(new LatLng(26.87237, 80.997067));
            mPathPolygonPointsSecond.Add(new LatLng(26.87248, 80.998068));
            mPathPolygonPointsSecond.Add(new LatLng(26.87259, 80.999069));
            mPathPolygonPointsSecond.Add(new LatLng(26.87262, 80.992061));
            mPathPolygonPointsSecond.Add(new LatLng(26.87273, 80.993062));
            mPathPolygonPointsSecond.Add(new LatLng(26.87284, 80.994063));
            mPathPolygonPointsSecond.Add(new LatLng(26.87295, 80.995064));
            mPathPolygonPointsSecond.Add(new LatLng(26.87306, 80.996065));
            mPathPolygonPointsSecond.Add(new LatLng(26.87317, 80.997066));
            mPathPolygonPointsSecond.Add(new LatLng(26.87328, 80.998067));
            mPathPolygonPointsSecond.Add(new LatLng(26.87336, 80.999068));
            mPathPolygonPointsSecond.Add(new LatLng(26.87347, 80.993069));
            mPathPolygonPointsSecond.Add(new LatLng(26.87358, 80.994061));
            mPathPolygonPointsSecond.Add(new LatLng(26.87369, 80.995062));

            mPathPolygonPointsSecond.Add(new LatLng(26.87171, 80.991061));
            mPathPolygonPointsSecond.Add(new LatLng(26.87182, 80.992062));
            mPathPolygonPointsSecond.Add(new LatLng(26.87193, 80.993063));
            mPathPolygonPointsSecond.Add(new LatLng(26.87204, 80.994064));
            mPathPolygonPointsSecond.Add(new LatLng(26.87215, 80.995065));
            mPathPolygonPointsSecond.Add(new LatLng(26.87226, 80.996066));
            mPathPolygonPointsSecond.Add(new LatLng(26.87237, 80.997067));
            mPathPolygonPointsSecond.Add(new LatLng(26.87248, 80.998068));
            mPathPolygonPointsSecond.Add(new LatLng(26.87259, 80.999069));
            mPathPolygonPointsSecond.Add(new LatLng(26.87262, 80.992061));
            mPathPolygonPointsSecond.Add(new LatLng(26.87273, 80.993062));
            mPathPolygonPointsSecond.Add(new LatLng(26.87284, 80.994063));
            mPathPolygonPointsSecond.Add(new LatLng(26.87295, 80.995064));
            mPathPolygonPointsSecond.Add(new LatLng(26.87306, 80.996065));
            mPathPolygonPointsSecond.Add(new LatLng(26.87317, 80.997066));
            mPathPolygonPointsSecond.Add(new LatLng(26.87328, 80.998067));
            mPathPolygonPointsSecond.Add(new LatLng(26.87336, 80.999068));
            mPathPolygonPointsSecond.Add(new LatLng(26.87347, 80.993069));
            mPathPolygonPointsSecond.Add(new LatLng(26.87358, 80.994061));
            mPathPolygonPointsSecond.Add(new LatLng(26.87369, 80.995062));

        }



        public void clean()
        {
            // googlemap.Clear();
            mMap.Clear();
        }

        public void OnMapReady(GoogleMap googleMap)
        {

            
            

            try
            {
                bool isSuccess = googleMap.SetMapStyle(MapStyleOptions.LoadRawResourceStyle(this, Resource.Raw.custommap));
                if (!isSuccess)
                   // Log.e(tag: "Error", Message: "Map Style");
                Toast.MakeText(this, "Map", ToastLength.Long).Show();
            }
            catch (Resources.NotFoundException ex)
            {
                ex.PrintStackTrace();
            }

            mMap = googleMap;
            LatLng myPosition = new LatLng(26.8612, 80.9864);
            LatLng redCarPosition = new LatLng(22.5811275, 88.4301834);
            LatLng SecondcarPosition = new LatLng(26.8622, 80.9874);

            // googleMap.SetMapStyle = maptypenormal;
            //   googleMap.SetMapStyle(GoogleMap.MapTypeNormal);
            //googleMap.setMyLocationEnabled(true);
            googleMap.MyLocationEnabled = true;
            googleMap.TrafficEnabled = false;
            // googleMap.IsIndoorEnabled = true;

            // googleMap.IndoorEnabled=false;
            //  googleMap.SetIndoorEnabled = false;
            googleMap.BuildingsEnabled = false;
            googleMap.UiSettings.ZoomControlsEnabled = true;
            //MapStyleOptions mapStyleOptions = MapStyleOptions.LoadRawResourceStyle(this, Resource.raw.google_mapstyle);
            //mMap.SetMapStyle(mapStyleOptions);


            googleMap.MoveCamera(CameraUpdateFactory.NewLatLng(myPosition));

            googleMap.MoveCamera(CameraUpdateFactory.NewLatLng(SecondcarPosition));

            googleMap.MoveCamera(CameraUpdateFactory.NewCameraPosition(new CameraPosition.Builder()
                    .Target(googleMap.CameraPosition.Target)
                    .Zoom(15)
                    .Bearing(30)
                    .Tilt(45)
                    .Build()));
            mMarkerIcon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.red2);

            mMarkerIcon1 = BitmapFactory.DecodeResource(Resources, Resource.Drawable.black1);

          //  mRedCarMarkerIcon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.black1);

           

            mCarMarker = googleMap.AddMarker(new MarkerOptions()
                   .SetPosition(myPosition)
                   .SetIcon(BitmapDescriptorFactory.FromBitmap(mMarkerIcon))
                   .SetTitle("I'm First Car"));


            mSecondcarMarker = googleMap.AddMarker(new MarkerOptions()
                    .SetPosition(SecondcarPosition)
                    .SetIcon(BitmapDescriptorFactory.FromBitmap(mMarkerIcon1))
                    .SetTitle("I'm Second Car"));
            

            //myRedCarMarkar = googleMap.AddMarker(new MarkerOptions()
            //        .SetPosition(redCarPosition)
            //        .SetIcon(BitmapDescriptorFactory.FromBitmap(mRedCarMarkerIcon))
            //        .SetTitle("I'm Here"));

          



            googleMap.AnimateCamera(CameraUpdateFactory.NewLatLng(mCarMarker.Position));
            if (ActivityCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted && ActivityCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessCoarseLocation) != Android.Content.PM.Permission.Granted)
            {

                return;
            }
            googleMap.MyLocationEnabled = true;
            System.Timers.Timer delay = new System.Timers.Timer();
            this.RunOnUiThread(() =>
            {
                animateCarMove(mCarMarker, mPathPolygonPoints[0], mPathPolygonPoints[1], MOVE_ANIMATION_DURATION);
               
            });


            googleMap.AnimateCamera(CameraUpdateFactory.NewLatLng(mSecondcarMarker.Position));
            if (ActivityCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted && ActivityCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessCoarseLocation) != Android.Content.PM.Permission.Granted)
            {

                return;
            }
           
           
            this.RunOnUiThread(() =>
            {
                animateCarMove1(mSecondcarMarker, mPathPolygonPointsSecond[0], mPathPolygonPointsSecond[1], MOVE_ANIMATION_DURATION1);
            });

        }
        public void animateCarMove(Marker marker, LatLng beginLatLng, LatLng endLatLng, float duration)
        {

            long startTime = SystemClock.UptimeMillis();
            Android.Views.Animations.IInterpolator interpolator = new Android.Views.Animations.LinearInterpolator();
            float angleDeg = (float)(180 * getAngle(beginLatLng, endLatLng) / System.Math.PI);
            
            Matrix matrix = new Matrix();
            matrix.PostRotate(angleDeg);
            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.black1));

          

            // marker.SetIcon(BitmapDescriptorFactory.FromBitmap(Bitmap.CreateBitmap(mMarkerIcon, 0, 0, mMarkerIcon.Width, mMarkerIcon.Height, matrix, true)));
            handler = new Handler();
            action1 = () =>
            {
                
                long elapsed = SystemClock.UptimeMillis() - startTime;
                float t = interpolator.GetInterpolation((float)elapsed / duration);
                // calculate new position for marker
                double lat = (endLatLng.Latitude - beginLatLng.Latitude) * t + beginLatLng.Latitude;
                double lngDelta = endLatLng.Longitude - beginLatLng.Longitude;

                if (System.Math.Abs(lngDelta) > 180)
                {
                    lngDelta -= System.Math.Sign(lngDelta) * 360;
                }
                double lng = lngDelta * t + beginLatLng.Longitude;
                marker.Position = new LatLng(lat, lng);
                if (t < 1.0)
                {
                    handler.PostDelayed(action1, 13);

                }
                else
                {
                    nextTurnAnimation();
                }


            };
            handler.Post(action1);

        }
        public void animateCarMove1(Marker SecondMarker, LatLng beginLatLng1, LatLng endLatLng1, float duration1)
        {

            long startTime1 = SystemClock.UptimeMillis();
            Android.Views.Animations.IInterpolator interpolator = new Android.Views.Animations.LinearInterpolator();
            float angleDeg1 = (float)(180 * getAngle(beginLatLng1, endLatLng1) / System.Math.PI);
            //float angleDeg = (float)(180 * getBearing(beginLatLng, endLatLng) / System.Math.PI);
            Matrix matrix1 = new Matrix();
            matrix1.PostRotate(angleDeg1);
            SecondMarker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.black1));



            // marker.SetIcon(BitmapDescriptorFactory.FromBitmap(Bitmap.CreateBitmap(mMarkerIcon, 0, 0, mMarkerIcon.Width, mMarkerIcon.Height, matrix, true)));
            handler1 = new Handler();
            action2 = () =>
            {
                // your code that you want to delay here
                long elapsed1 = SystemClock.UptimeMillis() - startTime1;
                float t1 = interpolator.GetInterpolation((float)elapsed1 / duration1);
                // calculate new position for marker
                double lat1 = (endLatLng1.Latitude - beginLatLng1.Latitude) * t1 + beginLatLng1.Latitude;
                double lngDelta1 = endLatLng1.Longitude - beginLatLng1.Longitude;

                if (System.Math.Abs(lngDelta1) > 180)
                {
                    lngDelta1 -= System.Math.Sign(lngDelta1) * 360;
                }
                double lng1 = lngDelta1 * t1 + beginLatLng1.Longitude;
                SecondMarker.Position = new LatLng(lat1, lng1);
                if (t1 < 1.0)
                {
                    handler1.PostDelayed(action2, 1);

                }
                else
                {
                    nextTurnAnimation1();
                }


            };
            handler1.Post(action2);

        }

        private void nextTurnAnimation()
        {
            mIndexCurrentPoint++;

            sizeoflist = mPathPolygonPoints.Count;
            if (mIndexCurrentPoint < sizeoflist - 1)
            {
                LatLng prevLatLng = mPathPolygonPoints[mIndexCurrentPoint - 1];
                LatLng currLatLng = mPathPolygonPoints[mIndexCurrentPoint];
                LatLng nextLatLng = mPathPolygonPoints[mIndexCurrentPoint + 1];



                float beginAngle = (float)(180 * getAngle(prevLatLng, currLatLng) / System.Math.PI);
                float endAngle = (float)(180 * getAngle(currLatLng, nextLatLng) / System.Math.PI);

                animateCarTurn(mCarMarker, beginAngle, endAngle, TURN_ANIMATION_DURATION);

            }

        } 
               

             private void nextTurnAnimation1()
        {
           
            mIndexCurrentPoint1++;
            
            sizeoflist1 = mPathPolygonPointsSecond.Count;
            {
                if (mIndexCurrentPoint1 < sizeoflist1 - 1)
                {
                    LatLng prevLatLng1 = mPathPolygonPointsSecond[mIndexCurrentPoint1 - 1];
                    LatLng currLatLng1 = mPathPolygonPointsSecond[mIndexCurrentPoint1];
                    LatLng nextLatLng1 = mPathPolygonPointsSecond[mIndexCurrentPoint1 + 1];



                    float beginAngle1 = (float)(180 * getAngle1(prevLatLng1, currLatLng1) / System.Math.PI);
                    float endAngle1 = (float)(180 * getAngle1(currLatLng1, nextLatLng1) / System.Math.PI);

                    animateCarTurn1(mSecondcarMarker, beginAngle1, endAngle1, TURN_ANIMATION_DURATION1);

                }
            }
        }

        public void animateCarTurn(Marker marker, float startAngle, float endAngle, float duration)
        {
            Handler handler = new Handler();
            long startTime = SystemClock.UptimeMillis();
            Android.Views.Animations.IInterpolator interpolator = new Android.Views.Animations.LinearInterpolator();
            float dAndgle = endAngle - startAngle;
            Matrix matrix = new Matrix();
            matrix.PostRotate(startAngle);
            Bitmap rotatedBitmap = Bitmap.CreateBitmap(mMarkerIcon, 0, 0, mMarkerIcon.Width, mMarkerIcon.Height, matrix, true);
            //marker.SetIcon(BitmapDescriptorFactory.FromBitmap(rotatedBitmap));
            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.red2));

           
            Handler h = new Handler();
            myAction1 = () =>
            {
                long elapsed = SystemClock.UptimeMillis() - startTime;
                float t = interpolator.GetInterpolation((float)elapsed / duration);

                Matrix m = new Matrix();
                m.PostRotate(startAngle + dAndgle * t);
                // marker.SetIcon(BitmapDescriptorFactory.FromBitmap(Bitmap.CreateBitmap(mMarkerIcon, 0, 0, mMarkerIcon.Width, mMarkerIcon.Height, m, true)));
                marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.red2));
               
                if (t < 1.0)
                {
                    h.PostDelayed(myAction1, 1000);
                }
                else
                {
                    nextMoveAnimation();
                }

            };

            h.Post(myAction1);
        }
        public void animateCarTurn1(Marker marker1, float startAngle1, float endAngle1, float duration1)
        {
            Handler handler1 = new Handler();
            long startTime1 = SystemClock.UptimeMillis();
            Android.Views.Animations.IInterpolator interpolator1 = new Android.Views.Animations.LinearInterpolator();
            float dAndgle1 = endAngle1 - startAngle1;
            Matrix matrix1 = new Matrix();
            matrix1.PostRotate(startAngle1);
            Bitmap rotatedBitmap1 = Bitmap.CreateBitmap(mMarkerIcon1, 0, 0, mMarkerIcon1.Width, mMarkerIcon1.Height, matrix1, true);
            //marker.SetIcon(BitmapDescriptorFactory.FromBitmap(rotatedBitmap));
           

            marker1.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.black1));
            Handler h1 = new Handler();
            myAction2 = () =>
            {
                long elapsed1 = SystemClock.UptimeMillis() - startTime1;
                float t1 = interpolator1.GetInterpolation((float)elapsed1 / duration1);

                Matrix m1 = new Matrix();
                m1.PostRotate(startAngle1 + dAndgle1 * t1);
                // marker.SetIcon(BitmapDescriptorFactory.FromBitmap(Bitmap.CreateBitmap(mMarkerIcon, 0, 0, mMarkerIcon.Width, mMarkerIcon.Height, m, true)));
               
                marker1.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.black1));
                if (t1 < 1.0)
                {
                    h1.PostDelayed(myAction2, 500);
                }
                else
                {
                    nextMoveAnimation1();
                }

            };

            h1.Post(myAction2);
        }

        public void nextMoveAnimation()
        {
            if (mIndexCurrentPoint < sizeoflist - 1)
            {
                animateCarMove(mCarMarker, mPathPolygonPoints[mIndexCurrentPoint], mPathPolygonPoints[mIndexCurrentPoint + 1], MOVE_ANIMATION_DURATION);
            }
           
        }

        public void nextMoveAnimation1()
        {
            
            if (mIndexCurrentPoint1 < sizeoflist1 - 1)
            {
                animateCarMove1(mSecondcarMarker, mPathPolygonPointsSecond[mIndexCurrentPoint1], mPathPolygonPointsSecond[mIndexCurrentPoint1 + 1], MOVE_ANIMATION_DURATION);
            }
        }

        private double getAngle(LatLng beginLatLng, LatLng endLatLng)
        {

            double f1 = System.Math.PI * beginLatLng.Latitude / 180;
            double f2 = System.Math.PI * endLatLng.Latitude / 180;
            double dl = System.Math.PI * (endLatLng.Longitude - beginLatLng.Longitude) / 180;
            return System.Math.Atan2(System.Math.Sin(dl) * System.Math.Cos(f2), System.Math.Cos(f1) * System.Math.Sin(f2) - System.Math.Sin(f1) * System.Math.Cos(f2) * System.Math.Cos(dl));
        }

        private double getAngle1(LatLng beginLatLng1, LatLng endLatLng1)
        {

            double f1 = System.Math.PI * beginLatLng1.Latitude / 180;
            double f2 = System.Math.PI * endLatLng1.Latitude / 180;
            double dl = System.Math.PI * (endLatLng1.Longitude - beginLatLng1.Longitude) / 180;
            return System.Math.Atan2(System.Math.Sin(dl) * System.Math.Cos(f2), System.Math.Cos(f1) * System.Math.Sin(f2) - System.Math.Sin(f1) * System.Math.Cos(f2) * System.Math.Cos(dl));
        }
        private float getBearing(LatLng begin, LatLng end)
        {
            double lat = System.Math.Abs(begin.Latitude - end.Latitude);
            double lng = System.Math.Abs(begin.Longitude - end.Longitude);

            if (begin.Latitude < end.Latitude && begin.Longitude < end.Longitude)
                return (float)(System.Math.Abs(System.Math.Atan(lng / lat)));
            else if (begin.Latitude >= end.Latitude && begin.Longitude < end.Longitude)
                return (float)((90 - System.Math.Abs(System.Math.Atan(lng / lat))) + 90);

            else if (begin.Latitude >= end.Latitude && begin.Longitude >= end.Longitude)
                return (float)(System.Math.Abs(System.Math.Atan(lng / lat)) + 180);
            else if (begin.Latitude < end.Latitude && begin.Longitude >= end.Longitude)
                return (float)((90 - System.Math.Abs(System.Math.Atan(lng / lat))) + 270);
            return -1;
        }

       

    }
}




//{



//    GoogleMap googlemap;



//    public List<Marker> markerList = new List<Marker>();




//    protected override void OnCreate(Bundle savedInstanceState)
//    {
//        base.OnCreate(savedInstanceState);
//        SetContentView(Resource.Layout.basic_demo);




//        var mapFragment = ((SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map));
//        mapFragment.GetMapAsync(this);
//    }


//void IOnMapReadyCallback.OnMapReady(GoogleMap map)
//   {
//       googlemap = map;
//        map.MyLocationEnabled = true;
//        // map.AddMarker(new MarkerOptions().SetPosition(new LatLng(26.8612, 80.9864)).SetTitle("Ashish"));
//        map.UiSettings.ZoomControlsEnabled = true;

//        LatLng latlng = new LatLng(Convert.ToDouble(26.8612), Convert.ToDouble(80.9864));
//        CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 14);
//        map.MoveCamera(camera);

//        MarkerOptions options = new MarkerOptions().SetPosition(latlng).SetTitle("Ashish").SetSnippet("Population: 4,400").Draggable(true);
//        map.AddMarker(options);


//        map.MapClick += (object sender, GoogleMap.MapClickEventArgs e) =>
//    {
//        using (var markerOption = new MarkerOptions())
//        {
//            markerOption.SetPosition(e.Point);
//            markerOption.SetTitle("Hello");
//            markerOption.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.car));
//            // var marker = map.AddMarker(markerOption);

//            Marker M = map.AddMarker(markerOption);
//            markerList.Add(M);


//            if (markerList.Count() >= 10)
//            {
//                clean();
//                markerList.Clear();
//            }

//            var polylineOptions = new PolylineOptions();
//            polylineOptions.InvokeColor(0x66FF0000);
//            polylineOptions.InvokeWidth(15);




//            for (int i = 0; i < markerList.Count; i++)


//            {
//                if (i != (markerList.Count - 1))
//                {
//                    polylineOptions.Add(markerList[i].Position, markerList[i + 1].Position);
//                    map.AddPolyline(polylineOptions);
//                }




//            }




//        }



//    };


//        map.MapLongClick += (object sender, GoogleMap.MapLongClickEventArgs e) =>
//         {

//             using (PolylineOptions rectOptions = new PolylineOptions())
//             {
//                 rectOptions


//                    .Add(new LatLng(26.8467, 80.9462))
//                        .Add(new LatLng(26.4499, 80.3319))
//                        .Add(new LatLng(27.1767, 78.0081))
//                        .Add(new LatLng(28.7041, 77.1025))
//                        .Add(new LatLng(26.8467, 80.9462));


//                 rectOptions.InvokeColor(0x66FF0000);
//                 rectOptions.InvokeWidth(15);


//                 Polyline polyline = map.AddPolyline(rectOptions);




//             }
//         };



//    }

//        public void clean()
//        {
//            googlemap.Clear();
//        }


//}


//}

