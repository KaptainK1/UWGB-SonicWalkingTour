﻿using System;
using System.Collections.Generic;
using CoreGraphics;
using MapKit;
using Plugin.SimpleAudioPlayer;
using SonicWalkingTour;
using SonicWalkingTour.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace SonicWalkingTour.iOS
{
    public class CustomMapRenderer : MapRenderer
    {
        UIView customPinView;
        List<CustomPin> customPins;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                nativeMap.GetViewForAnnotation = null;
                nativeMap.CalloutAccessoryControlTapped -= OnCalloutAccessoryControlTapped;
                nativeMap.DidSelectAnnotationView -= OnDidSelectAnnotationView;
                nativeMap.DidDeselectAnnotationView -= OnDidDeselectAnnotationView;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                var nativeMap = Control as MKMapView;
                customPins = formsMap.CustomPins;

                nativeMap.GetViewForAnnotation = GetViewForAnnotation;
                nativeMap.CalloutAccessoryControlTapped += OnCalloutAccessoryControlTapped;
                nativeMap.DidSelectAnnotationView += OnDidSelectAnnotationView;
                nativeMap.DidDeselectAnnotationView += OnDidDeselectAnnotationView;
            }
        }

        protected override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;

            if (annotation is MKUserLocation)
                return null;


            var anno = annotation as MKPointAnnotation;
            if (anno == null)
                return null;

            var customPin = GetCustomPin(anno);
            if (customPin == null)
            {
                throw new Exception("Custom pin not found");
            }

            annotationView = mapView.DequeueReusableAnnotation(customPin.MarkerId.ToString());
            if (annotationView == null)
            {
                annotationView = new CustomMKAnnotationView(annotation, customPin.MarkerId.ToString());
                annotationView.Image = UIImage.FromFile("pin.png");
                annotationView.CalloutOffset = new CGPoint(0, 0);
                annotationView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromFile("monkey.png"));
                annotationView.RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure);
                ((CustomMKAnnotationView)annotationView).MarkerId = customPin.MarkerId.ToString();
                ((CustomMKAnnotationView)annotationView).Url = customPin.Url;
            }
            annotationView.CanShowCallout = true;

            return annotationView;
        }

        void OnCalloutAccessoryControlTapped(object sender, MKMapViewAccessoryTappedEventArgs e)
        {
            var customView = e.View as CustomMKAnnotationView;
            var position = new Position(customView.Annotation.Coordinate.Latitude, customView.Annotation.Coordinate.Longitude);
            var customPin = GetCustomPin(position);
            if (!string.IsNullOrWhiteSpace(customView.Url))
            {
                //App.Current.MainPage.Navigation.PushAsync(new PinDetailPage(customPin));
                Shell.Current.GoToAsync($"pinDetailPage?stopid={customPin.StopID}");
            }
        }

        //method to create a new annotation when a pin is selected
        void OnDidSelectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            var customView = e.View as CustomMKAnnotationView;
            customPinView = new UIView();

            //if (customView.MarkerId == "Xamarin")
            //{
                customPinView.Frame = new CGRect(0, 0, 200, 84);
                var image = new UIImageView(new CGRect(0, 0, 200, 84));
                image.Image = UIImage.FromFile("xamarin.png");
                customPinView.AddSubview(image);
                customPinView.Center = new CGPoint(0, -(e.View.Frame.Height + 75));
                e.View.AddSubview(customPinView);

            //}
        }

        void OnDidDeselectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            if (!e.View.Selected)
            {
                customPinView.RemoveFromSuperview();
                customPinView.Dispose();
                customPinView = null;
            }
        }

        CustomPin GetCustomPin(MKPointAnnotation annotation)
        {
            var position = new Position(annotation.Coordinate.Latitude, annotation.Coordinate.Longitude);
            foreach (var pin in customPins)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }

        CustomPin GetCustomPin(Position position)
        {
            //var position = new Position(annotation.Coordinate.Latitude, annotation.Coordinate.Longitude);
            foreach (var pin in customPins)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }

    }
}
