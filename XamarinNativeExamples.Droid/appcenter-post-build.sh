# Environment Variables created by App Center
# $APPCENTER_SOURCE_DIRECTORY
# $APPCENTER_OUTPUT_DIRECTORY
# $APPCENTER_BRANCH

# Custom Environment Variables
# $API_KEY
# $TEAM_APP
# $DEVICE_SET
UITEST_PATH='XamarinNativeExamples.UITest'

# DEBUGGING
echo "start post-build script!"
echo "Referencing source directory: " $APPCENTER_SOURCE_DIRECTORY
echo "Contents: "
ls $APPCENTER_SOURCE_DIRECTORY
echo "& output directory: " $APPCENTER_OUTPUT_DIRECTORY
echo "Contents: "
ls $APPCENTER_OUTPUT_DIRECTORY

# Build UITest project
eval MSBuild $APPCENTER_SOURCE_DIRECTORY/$UITEST_PATH -v:q 

# DEBUGGING
echo "contents of UITest directory:" 
ls $APPCENTER_SOURCE_DIRECTORY/$UITEST_PATH

# Upload tests
App_Center_Test_Command='appcenter test run uitest --app $TEAM_APP --devices $DEVICE_SET --app-path $APPCENTER_OUTPUT_DIRECTORY/com.appcenter.UITestDemo.apk  --test-series "gh-$APPCENTER_BRANCH" --locale "en_US" --build-dir $APPCENTER_SOURCE_DIRECTORY/$UITEST_PATH/bin/Debug --async --token $API_KEY --uitest-tools-dir $APPCENTER_SOURCE_DIRECTORY/packages/Xamarin.UITest.*/tools'

echo $App_Center_Test_Command
eval $App_Center_Test_Command

# End
echo "end post-build script"