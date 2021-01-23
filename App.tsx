import React, {useCallback, useEffect, useState} from 'react';
import {
  SafeAreaView,
  ScrollView,
  View,
  Text,
  StatusBar,
  AppStateStatus,
  AppState,
} from 'react-native';

import {Header} from 'react-native/Libraries/NewAppScreen';

export const useAppState = () => {
  const [appState, setAppState] = useState(AppState.currentState);

  const changeHandler = useCallback(
    (currentState: AppStateStatus) => {
      console.log(
        `current app state ${currentState} | previous app state ${appState}`,
      );
      setAppState(currentState);
    },
    [appState],
  );

  useEffect(() => {
    AppState.addEventListener('change', changeHandler);
    return () => AppState.removeEventListener('change', changeHandler);
  }, [changeHandler]);
  return appState;
};

const App = () => {
  const appState = useAppState();
  console.log('App State', appState);
  return (
    <>
      <StatusBar barStyle="dark-content" />
      <SafeAreaView>
        <ScrollView contentInsetAdjustmentBehavior="automatic">
          <Header />
          <View>
            <View>
              <Text>Look in the console for changes</Text>
            </View>
          </View>
        </ScrollView>
      </SafeAreaView>
    </>
  );
};

export default App;
